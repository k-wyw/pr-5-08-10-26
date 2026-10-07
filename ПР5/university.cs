using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    public class university
    {
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public List<Course> Courses { get; private set; }

        public university()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }
    }

}