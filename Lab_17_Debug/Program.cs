#define PHILTEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting app");
#if DEBUG
            Console.WriteLine("debug");
#endif
            Console.WriteLine("finished app");

#if PHILTEST
            Console.WriteLine("phillip");
#endif
        }
    }
}
