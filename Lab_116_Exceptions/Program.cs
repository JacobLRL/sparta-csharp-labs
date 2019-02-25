using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_116_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 0;
            try
            {
                try
                {
                    int z = x / y;
                    throw new Exception("Phils exception");
                }
                catch (DivideByZeroException d) {
                    Console.WriteLine(d.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("something");
                    throw;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("done");
            }
        }
    }
}
