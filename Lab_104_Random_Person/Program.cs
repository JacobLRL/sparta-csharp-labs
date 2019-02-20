using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_104_Random_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            GenPerson();
        }

        public static void GenPerson() {
            DateTime now = DateTime.Now;
            DateTime finish = now.AddSeconds(100);
            while (true)
            {
                Parent parent = new Parent();
                parent.Randomise();
                Console.WriteLine($"Name: {parent.Name}, DOB: {parent.DOB.ToString("MM/dd/yyyy")} and Age: {parent.Age}");
                if (DateTime.Compare(DateTime.Now, finish) >= 0) break;
                Thread.Sleep(1000);
            }
        }
    }

    class Parent {
        string[] randFirstName = new string[] { "Adam", "Luke", "Amira", "Seb", "Desmond", "Sam", "Aneisha", "Nadi", "JDareen", "Mage", "Jake", "Michael" };
        string[] randLastName = new string[] { "Goddard", "Dawes", "Shah", "Rodriguez", "Nembhard", "Bowden-Williams", "Mallikaratchy", "Adem", "Garces", "Hussain", "Little", "Wright" };
        public Parent() {
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        private DateTime start = new DateTime(1919, 1, 1);
        private DateTime today = DateTime.Today;

        public void Randomise() {
            string first = randFirstName[RandomNumber(0, randFirstName.Length)];
            string second = randLastName[RandomNumber(0, randLastName.Length)];
            Name = $"{first} {second}";
            DOB = RandomDay();
            Age = today.Year - DOB.Year;
            if (DOB > today.AddYears(-Age)) Age--;
        }

        DateTime RandomDay()
        {
            int range = (today - start).Days;
            return start.AddDays(RandomNumber( 0, range));
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
