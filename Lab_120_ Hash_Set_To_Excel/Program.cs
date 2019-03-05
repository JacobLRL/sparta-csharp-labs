using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_120_Hash_Set_To_Excel
{
    /*
         * Start stopwatch
         * Pass 3 numbers to an array
         * double the numbers and pass to a linked list
         * double numbers and put into hash set
         * add 15, treble numbers and pass to dictionary
         * stop the stopwatch
         * Return the test as a CUSTOM OBJECT CONTAINING
         *  Elapsed time(int in milliseconds)
         *  First numbers
         *  Second number
         *  Third number
         * test passes if stopwatch time less than time passed in (4th var)( set to 10 secs)
         * Not part of the test
         * output all values to .csv text file and append to existing file.
         *  INPUT 4 PARAMS
         *  OUTPUT 4 APRAMS
         *  Finally launch excel to read this file using Process.Start
         * 
         * */
    class Program
    {
        static void Main(string[] args)
        {
            HashSetToExcel hash = new HashSetToExcel();
            hash.HashSetToExcelTest(1,2,3);
            hash.HashSetToExcelTest(5,2,3);
            hash.HashSetToExcelTest(1,6,3);
        }
    }

    public class HashSetToExcel {
        public Custom HashSetToExcelTest(int a, int b, int c) {
            int[] arr = { a, b, c };
            LinkedList<int> list = new LinkedList<int>();
            HashSet<int> hash = new HashSet<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Stopwatch s = new Stopwatch();
            s.Start();
            foreach (var elem in arr) {
                list.AddLast(elem*2);
            }
            foreach (var elem in list) {
                hash.Add(elem * 2);
            }
            for (int i = 0; i < hash.Count; i++) {
                dict.Add(i,(hash.ElementAt(i)+15)*3);
            }
            Custom custom = new Custom(dict[0], dict[1], dict[2], (int)s.ElapsedMilliseconds);
            
            Console.WriteLine($"a:{dict[0]}\nb:{dict[1]}\nc:{dict[2]}\nelapsedTime:{custom.elapsedTime}");

            string newFileName = "file.csv";
            if (!File.Exists(newFileName))
            {
                string header = "number 1,number 2,number 3,time" + Environment.NewLine;

                File.WriteAllText(newFileName, header);
            }
            string data = $"{custom.a},{custom.b},{custom.c},{custom.elapsedTime}{Environment.NewLine}";
            File.AppendAllText(newFileName, data);
            Process.Start(newFileName);
            s.Stop();
            return custom;
        }
    }


    public class Custom {
        public int elapsedTime, a, b, c;
        public Custom() { }
        public Custom(int a, int b, int c, int d) {
            this.a = a;
            this.b = b;
            this.c = c;
            elapsedTime = d;
        }
    }
}
