using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab_19_Streaming
{
    class Program
    {
        static string line;
        static List<string> list = new List<string>();
        static void Main(string[] args)
        {
            // Main thread !!!
            Console.WriteLine("program started");
            ReadData();
            Console.WriteLine("sleep finished");
            ReadDataAsync();
            Console.WriteLine("finished");
            Console.ReadLine();
        }

        static void ReadData() {
            Thread.Sleep(2000);
        }

        async static void ReadDataAsync()
        {
            using (var reader = new StreamReader("data.txt")) {
                while (true) {
                    line = await reader.ReadLineAsync();
                    if (line == null) break;
                    list.Add(line);
                }
            }
            Console.WriteLine("read file suhhh");

            list.ForEach(something => Console.WriteLine(something));
            Console.WriteLine($"code has {list.Count()} lines");
        }
    }
}
