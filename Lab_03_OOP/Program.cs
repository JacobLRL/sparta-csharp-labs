using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            Parent parent1 = new Parent("Phil", 007);
        }
    }

    class Parent {
        public string Name { get; set; }
        public int Age { get; set; }

        public Parent() {}

        public Parent(string name, int age){
            this.Name = name;
            this.Age = age;
        }
    }
}
