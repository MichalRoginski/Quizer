using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreDataAccessLib.Models
{
    public class Quiz
    {
        public int id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Quiz name:")]
        [RegularExpression(@"^[a-zA-Z0-9 ?!]*$", ErrorMessage = "Only letters and numbers or ?!")]
        public string name { get; set; }
        [Required]
        [Range(0, 20)]
        [Display(Name = "How many questions:")]
        public int numberOfQuestions { get; set; }
        [Required]
        [Display(Name = "Category:")]
        public string category { get;set; }
       
        public ICollection<Question> questions { get; set; }
 

    }
}
