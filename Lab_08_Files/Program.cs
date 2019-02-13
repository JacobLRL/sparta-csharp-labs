using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_08_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string data01 = File.ReadAllText("file.txt");
            Console.WriteLine(data01);

            File.WriteAllText("file2.txt", "suhhh dude \n new line");
            Console.WriteLine(File.ReadAllText("file2.txt"));
            Console.Read();
        }
    }
}
