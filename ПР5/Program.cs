using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            university university = new university();
            Teacher t1 = new Teacher("Петров Пётр Петрович", 45, "petrov@univ.ru", "Математика");
            Teacher t2 = new Teacher("Сидорова Анна Ивановна", 38, "sidorova@univ.ru", "Программирование");
            university.Teachers.Add(t1);
            university.Teachers.Add(t2);

            Course c1 = new Course("Математический анализ", t1);
            Course c2 = new Course("Основы C#", t2);
            university.Courses.Add(c1);
            university.Courses.Add(c2);

            t1.AssignCourse(c1.Title);
            t2.AssignCourse(c2.Title);

            Student s1 = new Student("Иванов Иван Иванович", 19, "ivanov@stud.ru", "ПИ-21");
            Student s2 = new Student("Кузнецова Ольга Валерьевна", 20, "kuznetsova@stud.ru", "ПИ-21");
            university.Students.Add(s1);
            university.Students.Add(s2);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n Университет ");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Добавить преподавателя");
                Console.WriteLine("3. Создать курс");
                Console.WriteLine("4. Записать студента на курс");
                Console.WriteLine("5. Показать всех студентов");
                Console.WriteLine("6. Показать всех преподавателей");
                Console.WriteLine("7. Показать все курсы");
                Console.WriteLine("8. Курсы конкретного студента");
                Console.WriteLine("9. Студенты конкретного курса");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(university); break;
                    case "2": AddTeacher(university); break;
                    case "3": AddCourse(university); break;
                    case "4": EnrollStudent(university); break;
                    case "5": ShowAllStudents(university); break;
                    case "6": ShowAllTeachers(university); break;
                    case "7": ShowAllCourses(university); break;
                    case "8": ShowStudentCourses(university); break;
                    case "9": ShowCourseStudents(university); break;
                    case "0": running = false; Console.WriteLine("Выход"); break;
                    default: Console.WriteLine("Неверный пункт."); break;
                }
            }
        }

        // 1. Добавить студента
        static void AddStudent(university university)
        {
            Console.WriteLine("\n Добавление студента ");

            string name = ReadNonEmptyString("Имя: ");
            int age = ReadPositiveInt("Возраст: ", 16, 100);
            string contact = ReadNonEmptyString("Контакт: ");
            string group = ReadNonEmptyString("Группа: ");

            Student student = new Student(name, age, contact, group);
            university.Students.Add(student);
            Console.WriteLine("Студент добавлен.");
        }

        // 2. Добавить преподавателя
        static void AddTeacher(university university)
        {
            Console.WriteLine("\n Добавление преподавателя ");

            string name = ReadNonEmptyString("Имя: ");
            int age = ReadPositiveInt("Возраст: ", 18, 100);
            string contact = ReadNonEmptyString("Контакт: ");
            string subject = ReadNonEmptyString("Предмет: ");

            Teacher teacher = new Teacher(name, age, contact, subject);
            university.Teachers.Add(teacher);
            Console.WriteLine("Преподаватель добавлен.");
        }

        // 3. Создать курс
        static void AddCourse(university university)
        {
            Console.WriteLine("\n Создание курса ");

            if (university.Teachers.Count == 0)
            {
                Console.WriteLine("Сначала добавьте хотя бы одного преподавателя.");
                return;
            }

            string title = ReadNonEmptyString("Название курса: ");

            Console.WriteLine("Выберите преподавателя:");
            for (int i = 0; i < university.Teachers.Count; i++)
                Console.WriteLine($"{i + 1}. {university.Teachers[i].Name} ({university.Teachers[i].Subject})");

            int index = ReadPositiveInt("Номер преподавателя: ", 1, university.Teachers.Count) - 1;
            Teacher teacher = university.Teachers[index];

            Course course = new Course(title, teacher);
            university.Courses.Add(course);
            teacher.AssignCourse(title);
            Console.WriteLine("Курс создан.");
        }

        // 4. Записать студента на курс
        static void EnrollStudent(university university)
        {
            Console.WriteLine("\n Запись на курс ");

            if (university.Students.Count == 0 || university.Courses.Count == 0)
            {
                Console.WriteLine("Нужны хотя бы один студент и один курс.");
                return;
            }

            Console.WriteLine("Выберите студента:");
            for (int i = 0; i < university.Students.Count; i++)
                Console.WriteLine($"{i + 1}. {university.Students[i].Name}");

            int sIndex = ReadPositiveInt("Номер студента: ", 1, university.Students.Count) - 1;
            Student student = university.Students[sIndex];

            Console.WriteLine("Выберите курс:");
            for (int i = 0; i < university.Courses.Count; i++)
                Console.WriteLine($"{i + 1}. {university.Courses[i].Title}");

            int cIndex = ReadPositiveInt("Номер курса: ", 1, university.Courses.Count) - 1;
            Course course = university.Courses[cIndex];

            if (student.Courses.Contains(course.Title))
            {
                Console.WriteLine("Студент уже записан на этот курс.");
                return;
            }

            student.EnrollCourse(course.Title);
            course.AddStudent(student);
            Console.WriteLine("Студент записан.");
        }

        // 5. Показать всех студентов (полиморфизм — работаем через Person)
        static void ShowAllStudents(university university)
        {
            Console.WriteLine("\n Все студенты ");
            if (university.Students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            foreach (Person p in university.Students)
            {
                Console.WriteLine($"[{p.GetRole()}]");
                p.PrintInfo();
            }
        }

        // 6. Показать всех преподавателей
        static void ShowAllTeachers(university university)
        {
            Console.WriteLine("\n Все преподаватели ");
            if (university.Teachers.Count == 0)
            {
                Console.WriteLine("Преподавателей нет.");
                return;
            }

            foreach (Person p in university.Teachers)
            {
                Console.WriteLine($"[{p.GetRole()}]");
                p.PrintInfo();
            }
        }

        // 7. Показать все курсы 
        static void ShowAllCourses(university university)
        {
            Console.WriteLine("\n Все курсы ");
            if (university.Courses.Count == 0)
            {
                Console.WriteLine("Курсов нет.");
                return;
            }

            var sorted = university.Courses.OrderBy(c => c.Title).ToList();
            foreach (Course c in sorted)
                c.PrintInfo();
        }

        // 8. Курсы конкретного студента
        static void ShowStudentCourses(university university)
        {
            Console.WriteLine("\n Курсы студента ");
            if (university.Students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            Console.WriteLine("Выберите студента:");
            for (int i = 0; i < university.Students.Count; i++)
                Console.WriteLine($"{i + 1}. {university.Students[i].Name}");

            int index = ReadPositiveInt("Номер: ", 1, university.Students.Count) - 1;
            Student student = university.Students[index];

            if (student.Courses.Count == 0)
            {
                Console.WriteLine("Студент не записан ни на один курс.");
                return;
            }

            var sorted = student.Courses.OrderBy(c => c).ToList();
            foreach (string c in sorted)
                Console.WriteLine($"- {c}");
        }

        // 9. Студенты конкретного курса 
        static void ShowCourseStudents(university university)
        {
            Console.WriteLine("\n Студенты курса ");
            if (university.Courses.Count == 0)
            {
                Console.WriteLine("Курсов нет.");
                return;
            }

            Console.WriteLine("Выберите курс:");
            for (int i = 0; i < university.Courses.Count; i++)
                Console.WriteLine($"{i + 1}. {university.Courses[i].Title}");

            int index = ReadPositiveInt("Номер: ", 1, university.Courses.Count) - 1;
            Course course = university.Courses[index];

            if (course.Students.Count == 0)
            {
                Console.WriteLine("На курс никто не записан.");
                return;
            }

            var sorted = course.Students.OrderBy(s => s.Name).ToList();
            foreach (Student s in sorted)
                Console.WriteLine($"- {s.Name}");
        }

        // Вспомогательные методы для проверки ввода 

        // Читает непустую строку
        static string ReadNonEmptyString(string prompt)
        {
            string result = "";
            while (result == "")
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if (result == "")
                    Console.WriteLine("Поле не может быть пустым.");
            }
            return result;
        }

        // Читает целое число в заданном диапазоне
        static int ReadPositiveInt(string prompt, int min, int max)
        {
            int result = 0;
            while (result < min || result > max)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) == false)
                {
                    Console.WriteLine("Введите число.");
                    result = 0;
                }
                else if (result < min || result > max)
                {
                    Console.WriteLine($"Число должно быть от {min} до {max}.");
                }
            }
            return result;
        }
    }
}
