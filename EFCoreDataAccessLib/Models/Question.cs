using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDataAccessLib.Models
{
    public class Question
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Question:")]
        public string question { get; set; }
        [Required]
        [Display(Name = "Incorrect answer#1:")]
        public string badanswer1 { get; set; }
        [Required]
        [Display(Name = "Incorrect answer#2:")]
        public string badanswer2 { get; set; }
        [Required]
        [Display(Name = "Incorrect answer#3:")]
        public string badanswer3 { get; set; }
        [Required]
        [Display(Name = "Correct answer:")]
        public string goodanswer { get; set; }
        public ICollection<Quiz> quizes { get; set; }

    }
}
