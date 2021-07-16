using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practical_WAD.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Start Time")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Please enter Exam Date")]
        public string ExamDate { get; set; }

        [Required(ErrorMessage = "Please enter Exam Duration")]
        public string ExamDuration { get; set; }

        public int ExamSubjectID { get; set; }
        public int ClassroomID { get; set; }
        public int FacultyID { get; set; }

        public virtual ExamSubject ExamSubject { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}