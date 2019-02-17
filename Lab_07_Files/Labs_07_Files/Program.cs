using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labs_07_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string data01 = File.ReadAllText("file.txt");
                Console.WriteLine(data01);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught");
            }
            finally
            {
                Console.WriteLine("buss it down thotiana");
            }
            Console.Read();
        }
    }
}
