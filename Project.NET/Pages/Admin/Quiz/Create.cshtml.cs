using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCoreDataAccessLib.Models;
using Microsoft.Extensions.Configuration;
using Project.NET.DataAccess;

namespace Project.NET.Pages
{
    public class CreateQuizModel : PageModel
    {
        private readonly EFCoreDataAccessLib.DataAccess.QuizContext _context;
        private readonly Ado_Net db;
        private readonly IConfiguration configuration;

        public CreateQuizModel(EFCoreDataAccessLib.DataAccess.QuizContext context, IConfiguration configuration,Ado_Net dbAccessService)
        {
            _context = context;
            this.configuration = configuration;
            db = dbAccessService;
        }

        public IActionResult OnGet()
        {
            AreChecked = new MultiSelectList(_context.questions, nameof(Question.id), nameof(Question.question));
            categories = db.GetCategories(configuration);
            return Page();
        }
        
        [BindProperty]
        public Quiz Quiz { get; set; }
        [BindProperty]
        public List<int> quizes { get; set; }
        public MultiSelectList AreChecked { get; set; }
        public List<string> categories { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Quiz.questions = new List<Question>();
            foreach(int i in quizes)
            {
                Quiz.questions.Add(_context.questions.Where(x => x.id == i).First());
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.quizzes.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
