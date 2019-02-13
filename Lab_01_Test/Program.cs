using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // constructor
            var object1 = new Object();
            // object literal
            var object2 = new
            {
                name = "hi",
                age = 22,
                dob = "21/09/1968"
            };
        }
    }
}
