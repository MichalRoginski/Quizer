using EFCoreDataAccessLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.NET.Pages
{
    public class IndexModel : PageModel
    {
        //admin-password
        //bucik-moje
        //konserwator-zaqwsx
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public IndexModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Quiz> quizes { get; set; }
        [BindProperty]
        public int quizId { get; set; }

        public void OnGet()
        {
            quizes = _context.quizzes.ToList();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/TakeQuiz", new { id = quizId });
        }
    }
}
