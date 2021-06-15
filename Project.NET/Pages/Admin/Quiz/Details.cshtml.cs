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
    public class DetailsQuizModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public DetailsQuizModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.quizzes.Include(x=>x.questions).FirstOrDefaultAsync(m => m.id == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
