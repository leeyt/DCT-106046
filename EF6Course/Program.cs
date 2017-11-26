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
            using (var db = new ContosoUniversityEntities())
            {
                var data = db.Course.ToList();

                foreach (var course in data)
                {
                    Console.WriteLine(course.Title);
                }
            }
        }
    }
}
