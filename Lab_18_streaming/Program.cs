using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_18_streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            // not using streaming => just writing the file directly
            // string file01 = File.ReadAllText("test.txt");

            // StreamReader - create StreamReader object
            //              - enclose in using block (complete cleanup afterwards)
            //              - ReadLine() stream and read line by line

            // path as variable - relative path
            string path01 = "data.txt";
            // absolute paths
            string path02 = "C:/data/data.txt";
            string path03 = "C:\\data\\data.txt";
            // @ means treat the following string literally
            string path04 = @"C:\data\data.txt";
            string path05 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\data.txt";
            Console.WriteLine(path05);
            using (var reader = new StreamReader(path05)) {
                string output;
                // read every line
                // output to string
                // test each time that the string is not null
                // continue looping intil out of data
                while ((output = reader.ReadLine())!=null) {
                    list.Add(output);
                }                
            }
            list.ForEach(output => Console.WriteLine(output));
            // StreamWriter
        }
    }
}
