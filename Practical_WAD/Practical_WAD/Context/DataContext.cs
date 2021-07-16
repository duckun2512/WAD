using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Practical_WAD.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Practical_WAD")
        {

        }

        public System.Data.Entity.DbSet<Practical_WAD.Models.Exam> Exams { get; set; }

        public System.Data.Entity.DbSet<Practical_WAD.Models.Classroom> Classrooms { get; set; }

        public System.Data.Entity.DbSet<Practical_WAD.Models.ExamSubject> ExamSubjects { get; set; }

        public System.Data.Entity.DbSet<Practical_WAD.Models.Faculty> Faculties { get; set; }
    }
}