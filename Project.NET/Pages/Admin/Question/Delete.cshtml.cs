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
    public class DeleteQuestionModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;

        public DeleteQuestionModel(EFCoreDataAccessLib.DataAccess.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.questions.FindAsync(id);

            if (Question != null)
            {
                _context.questions.Remove(Question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
