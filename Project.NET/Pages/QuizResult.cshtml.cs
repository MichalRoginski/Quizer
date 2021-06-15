using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDataAccessLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Project.NET.Pages.Shared
{
    public class QuizResultModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public QuizResultModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Quiz quiz { get; set; }
        [BindProperty]
        public string[] correctAnswers { get; set; }
        [BindProperty]
        public string[] badAnswParse { get; set; }
        [BindProperty]
        public string[] incorrectAnswers { get; set; }
        [BindProperty]
        public Dictionary<int,int> incorrectAnswersInt { get; set; }
        [BindProperty]
        public List<int> correctAnswersInt { get; set; }
        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("currentquiz") != null && HttpContext.Session.GetInt32("currentquiz") == id)
            {
                correctAnswersInt = new List<int>();
                incorrectAnswersInt = new Dictionary<int, int>();
                quiz = _context.quizzes.Include(x => x.questions).FirstOrDefault(m => m.id == id);
                if (HttpContext.Session.GetString("correctanswers") != null&&HttpContext.Session.GetString("correctanswers") != "")
                {
                    correctAnswers = HttpContext.Session.GetString("correctanswers").Split(' ');
                    foreach (string s in correctAnswers)
                    {
                        correctAnswersInt.Add(Convert.ToInt32(s));
                    }
                }
                if (HttpContext.Session.GetString("incorrectanswers") != null&& HttpContext.Session.GetString("incorrectanswers") != "")
                {
                    incorrectAnswers = HttpContext.Session.GetString("incorrectanswers").Split(' ');
                    foreach (string s in incorrectAnswers)
                    {
                        badAnswParse = s.Split(':');
                        incorrectAnswersInt.Add(Convert.ToInt32(badAnswParse[0]), Convert.ToInt32(badAnswParse[1]));
                    }
                }
                HttpContext.Session.SetInt32("currentquiz", (int)id);
                HttpContext.Session.SetInt32("currentquestion", 0);
                HttpContext.Session.SetString("correctanswers", "");
                HttpContext.Session.SetString("incorrectanswers", "");
                return null;
            }
            else
            {
                HttpContext.Session.SetInt32("currentquiz", (int)id);
                HttpContext.Session.SetInt32("currentquestion", 0);
                HttpContext.Session.SetString("correctanswers", "");
                HttpContext.Session.SetString("incorrectanswers", "");
                return RedirectToPage("/TakeQuiz", new { id = id });
            }
        }
    
    }
}
