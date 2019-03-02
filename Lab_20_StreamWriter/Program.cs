using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_20_StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //overwrite mode

            using (var writer = new StreamWriter("data.txt")) {
                for (int i = 0; i < 1000; i++) {
                    writer.WriteLine($"Data line {i}");
                }
            }

            //append

            using (var writer = new StreamWriter("data.txt", true))
            {
                writer.WriteLine("And some more");
            }

            //set encoding (UTF8 default)

            using (var writer = new StreamWriter("data.txt", true, Encoding.UTF8))
            {
                writer.WriteLine("Another One");
            }

            // huge files : can speed up the process by altering the 'buffer size'
            // which is the unit of data transfer
            using (var writer = new StreamWriter("data.txt", true, Encoding.UTF8, 10000))
            {
                writer.WriteLine("Lots of Data");
            }
        }
    }
}
