using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practical_WAD.Models
{
    public class ExamSubject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Subject Name")]
        public string ExamName { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}