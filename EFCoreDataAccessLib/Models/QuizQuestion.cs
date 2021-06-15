using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDataAccessLib.Models
{
    public class QuizQuestion
    {
        public int quizId { get; set; }
        public Quiz quiz { get; set; }
        public int questionId { get; set; }
        public Question question { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
