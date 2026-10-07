using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    public class Course
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Title { get; private set; }
        public Teacher Teacher { get; private set; }
        public List<Student> Students { get; private set; }

        public Course(string title, Teacher teacher)
        {
            Id = nextId;
            nextId = nextId + 1;
            Title = title;
            Teacher = teacher;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Курс | ID: {Id} | Название: {Title} | Преподаватель: {Teacher.Name}");
            if (Students.Count > 0)
            {
                Console.WriteLine("  Студенты:");
                foreach (Student s in Students)
                    Console.WriteLine($"    - {s.Name}");
            }
            else
            {
                Console.WriteLine("  Студенты: нет");
            }
        }
    }

}