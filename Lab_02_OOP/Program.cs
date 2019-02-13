using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog();
            dog.Name = "Doggo";
            Console.WriteLine(dog.Speak());
            //Console.ReadLine();

            dynamic x = 10; // works out typing when compiled
        }
    }

    class Animal {
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Animal() {
        }

        public Animal(string name, int age) {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Speak() {
            return "hello my dude";
        }
    }

    class Dog : Animal {

        public override string Speak() {
            
            return "woof " + Name;
        }
    }
}
