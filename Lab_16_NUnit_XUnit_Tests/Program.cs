using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_16_NUnit_XUnit_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TestMeNow {
        public double TestThisMethodWorks(double x, double y, double p) {
            // first 2 numbers multiplied then to the power of the 3rd input
            return Math.Pow((x*y), p);
        }
    }
}
