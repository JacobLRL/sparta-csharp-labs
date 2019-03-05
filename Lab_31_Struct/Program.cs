using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_31_Struct
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class X { }

    // fast memory, cant inherit from a struct also
    struct Point
    {
        public int Y, X;
        // constructor
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
