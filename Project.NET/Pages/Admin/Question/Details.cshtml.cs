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
    public class DetailsQuestionModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public DetailsQuestionModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.questions.FirstOrDefaultAsync(m => m.id == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
