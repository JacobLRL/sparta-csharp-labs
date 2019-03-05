using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_25_Checked_Unchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.MaxValue);
            int x = int.MaxValue;
            Console.WriteLine(++x);
            checked {
                Console.WriteLine(int.MaxValue);
                int y = int.MaxValue;
                double z = (double)y ++;
                Console.WriteLine(z);
            }
        }
    }
}
