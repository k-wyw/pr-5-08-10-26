using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР5
{
    public abstract class Person
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Contact { get; private set; }

        protected Person(string name, int age, string contact)
        {
            Id = nextId;
            nextId = nextId + 1;
            Name = name;
            Age = age;
            Contact = contact;
        }

        // Абстрактный метод — каждый наследник реализует по-своему
        // Полиморфизм: работаем через базовый тип
        public abstract void PrintInfo();

        // Обычный виртуальный метод — можно переопределить, но не обязательно
        public virtual string GetRole()
        {
            return "Человек";
        }
    }
}