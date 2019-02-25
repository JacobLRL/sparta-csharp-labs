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
            try
            {
                try
                {
                    throw new Exception("Phils exception");
                }
                catch (Exception)
                {
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
