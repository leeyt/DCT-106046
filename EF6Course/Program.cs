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
                var course = new Course
                {
                    Title = "Entity Framework 6",
                    CreditsRating = 100
                };
                course.Department = db.Department.Find(2);
                db.Course.Add(course);
                db.SaveChanges();
            }

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
