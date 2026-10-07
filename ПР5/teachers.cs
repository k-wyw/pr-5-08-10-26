using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    public class Teacher : Person
    {
        public string Subject { get; private set; }
        public List<string> Courses { get; private set; }

        public Teacher(string name, int age, string contact, string subject)
            : base(name, age, contact)
        {
            Subject = subject;
            Courses = new List<string>();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Преподаватель | ID: {Id} | Имя: {Name} | Возраст: {Age} | Контакт: {Contact} | Предмет: {Subject}");
            if (Courses.Count > 0)
                Console.WriteLine($"  Ведёт курсы: {string.Join(", ", Courses)}");
            else
                Console.WriteLine("  Ведёт курсы: нет");
        }

        public override string GetRole()
        {
            return "Преподаватель";
        }

        public void AssignCourse(string courseName)
        {
            Courses.Add(courseName);
        }
    }

}