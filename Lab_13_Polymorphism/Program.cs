using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Parent {
        // normal method
        public void DoThat() { }
        // method that could be overriden
        public virtual void DoThis() { }
    }
    class Child : Parent{
        //override parent method
        public override void DoThis() { }
    }
}
