using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP_Revision
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();
            var c = new Child();
            p.field = 0;
            c.field = 0;

        }
    }
    interface IDoSomething{}

    public class Parent {
        public int field;
    }
    // Inherit from parent
    // implement interface
    public class Child : Parent, IDoSomething { }

    //SEALED : no more children
    sealed class GrandChild { }
}
