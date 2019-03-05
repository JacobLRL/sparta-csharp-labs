using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_21_Push_Data_To_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var memoryStream = new MemoryStream()) {
                byte[] buffer = new byte[100];
                memoryStream.Write(buffer,0,0);
                memoryStream.Flush(); // send data

                memoryStream.Position = 0; // reset pointer to start

                // read data
                var reader = new StreamReader(memoryStream);
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
