using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDataAccessLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Project.NET.Pages
{
    public class TakeQuizModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public TakeQuizModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int currentQuestion { get; set; }
        [BindProperty]
        public int currentQuiz { get; set; }
        [BindProperty]
        public Quiz quiz { get; set; }
        [BindProperty]
        public List<Question> questions { get; set; }
        [BindProperty]
        public int numberOfQuestions { get; set; }
        [BindProperty]
        public int visibleQuestion { get; set; }
        [BindProperty]
        public string answer { get; set; }
        public IActionResult OnGet(int? id)
        {
            quiz = _context.quizzes.Where(x => x.id == id).FirstOrDefault();
            if (quiz==null)
                return RedirectToPage("/Index");
            if(HttpContext.Session.GetInt32("currentquiz") != null&&HttpContext.Session.GetInt32("currentquiz")==id)
            {
                currentQuiz = (int)id;
                currentQuestion = (int)HttpContext.Session.GetInt32("currentquestion");
                visibleQuestion = currentQuestion + 1;
                quiz= _context.quizzes.Include(x => x.questions).FirstOrDefault(m => m.id == id);
                questions = quiz.questions.ToList();
                return null;
            }
            else
            {
                HttpContext.Session.SetInt32("currentquiz",(int)id);
                HttpContext.Session.SetInt32("currentquestion", 0);
                HttpContext.Session.SetString("correctanswers", "");
                HttpContext.Session.SetString("incorrectanswers", "");
                return RedirectToPage("/TakeQuiz", new { id = id });
            }
        }
        public IActionResult OnPost()
        {
            if(answer=="good")
            {
                if(HttpContext.Session.GetString("correctanswers") != null&& HttpContext.Session.GetString("correctanswers") != "")
                {
                    HttpContext.Session.SetString("correctanswers", HttpContext.Session.GetString("correctanswers")+" "+currentQuestion.ToString());
                }
                else HttpContext.Session.SetString("correctanswers", currentQuestion.ToString());
            }
            else
            {
                if (HttpContext.Session.GetString("incorrectanswers") != null && HttpContext.Session.GetString("incorrectanswers") != "")
                {
                    HttpContext.Session.SetString("incorrectanswers", HttpContext.Session.GetString("incorrectanswers") + " " + currentQuestion.ToString() + ":" + answer);
                }
                else HttpContext.Session.SetString("incorrectanswers", currentQuestion.ToString()+":"+answer);
            }

            if ((int)HttpContext.Session.GetInt32("currentquestion") + 1 != numberOfQuestions)
                HttpContext.Session.SetInt32("currentquestion", (int)HttpContext.Session.GetInt32("currentquestion") + 1);
            else return RedirectToPage("/QuizResult",new { id=currentQuiz});
            return RedirectToPage("/TakeQuiz", new { id = currentQuiz });
        }
    }
}
