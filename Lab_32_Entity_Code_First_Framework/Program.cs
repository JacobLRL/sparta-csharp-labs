using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab_32_Entity_Code_First_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CollegeContext())
            {
                var student01 = new Student
                {
                    StudentName = "Swag on you",
                    Height = 178,
                    Weight = (float)70.5
                };
                db.Students.Add(student01);
                db.SaveChanges();
            }
            List<Student> students = new List<Student>();
            using (var db = new CollegeContext()) {
                students = db.Students.ToList();
            }
            students.ForEach(s => Console.WriteLine($"StudentID: {s.StudentID} StudentName: {s.StudentName}"));
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Qualification Qualification { get; set; }
    }

    public class Qualification
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }

    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("TestCollegeDB") { } // bounce responsibility  back up to entity dbcontext to do all the work
        public DbSet<Student> Students { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
    }
}
