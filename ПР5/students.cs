using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    public class Student : Person
    {
        public string Group { get; private set; }
        public List<string> Courses { get; private set; }

        public Student(string name, int age, string contact, string group)
            : base(name, age, contact)
        {
            Group = group;
            Courses = new List<string>();
        }

        // Переопределяем абстрактный метод
        public override void PrintInfo()
        {
            Console.WriteLine($"Студент | ID: {Id} | Имя: {Name} | Возраст: {Age} | Контакт: {Contact} | Группа: {Group}");
            if (Courses.Count > 0)
                Console.WriteLine($"  Курсы: {string.Join(", ", Courses)}");
            else
                Console.WriteLine("  Курсы: нет");
        }

        public override string GetRole()
        {
            return "Студент";
        }

        public void EnrollCourse(string courseName)
        {
            Courses.Add(courseName);
        }
    }
}