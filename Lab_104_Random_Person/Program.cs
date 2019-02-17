using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_104_Random_Person
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Parent {
        string[] randFirstName = new string[] { "Adam", "Luke", "Amira", "Seb", "Desmond", "Sam", "Aneisha", "Nadi", "JDareen", "Mage", "Jake", "Michael" };
        string[] randLastName = new string[] { "Goddard", "Dawes", "Shah", "" };
        public Parent() {

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        public void Randomise() {
            Name = "";
        }
    }
}
