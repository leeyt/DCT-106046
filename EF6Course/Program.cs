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
