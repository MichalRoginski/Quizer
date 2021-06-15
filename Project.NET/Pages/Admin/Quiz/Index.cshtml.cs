using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCoreDataAccessLib.Models;

namespace Project.NET.Pages
{
    public class IndexQuizModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public IndexQuizModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; }

        public async Task OnGetAsync()
        {
            Quiz = await _context.quizzes.ToListAsync();
        }
    }
}
