using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Course
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCourse_Git();
            GetDepartmentsWithCourses();
        }

        private static void GetDepartmentsWithCourses()
        {
            using (var db = new ContosoUniversityEntities())
            {
                db.Database.Log = Console.WriteLine;

                //GetCourse_Git();
                //GetDepartments(db);

                // Add
                //AddCourse(db);

                // Update
                //UpdateCourse(db);

                // Delete
                var course = db.Course.Find(9);
                db.Course.Remove(course);
                db.SaveChanges();
            }

        }

        private static void UpdateCourse(ContosoUniversityEntities db)
        {
            var courses = db.Course.Where(c => c.Title.Contains("Git"));
            foreach (var course in courses)
            {
                course.CreditsRating += 10;
            }
            db.SaveChanges();
        }

        private static void AddCourse(ContosoUniversityEntities db)
        {
            var course = new Course
            {
                Title = "Entity Framework 6",
                CreditsRating = 100
            };
            course.Department = db.Department.Find(2);
            db.Course.Add(course);
            db.SaveChanges();
        }

        private static void GetDepartments(ContosoUniversityEntities db)
        {
            // var departments = db.Department;
            var departments = db.Department.Include("Course");

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
                foreach (var course in department.Course)
                {
                    Console.WriteLine("\t" + course.Title);
                }
            }
        }

        private static void GetCourse_Git()
        {
            using (var db = new ContosoUniversityEntities())
            {
                //var data = db.Course.ToList();
                //var data = db.Course.Where(c => c.Title.Contains("Git")).ToList();
                var data = (from p in db.Course
                            where p.Title.Contains("Git")
                            select p).ToList();

                foreach (var course in data)
                {
                    Console.WriteLine(course.Title);
                }
            }
        }
    }
}
