using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Lab_118_Array_of_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperationAsync files = new FileOperationAsync();
            var s = new Stopwatch();
            s.Start();
            files.FileWrite(1000);
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
        }
    }

    public class FileOperationSyncronous
    {

        public string FileReadWrite(int numFiles) {
            string data = "Saving some data - ";
            // create stopwatch
            var s = new Stopwatch();
            s.Start();
            // write to file 000 times syncronously
            for (int i = 0; i < numFiles; i++)
            {
                File.WriteAllText("data.txt", data + i);
            }
            // red 000 times
            for (int i = 0; i < numFiles; i++)
            {
                File.ReadAllText("data.txt");
            }
            // end stopwtch
            s.Stop();
            return $"Total time = {s.ElapsedMilliseconds}";
        }
    }

    public class FileOperationAsync {

        public void FileWrite(int numFiles) {
            var tasks = new Task[numFiles];
            for (int i = 0; i < numFiles; i++)
            {
                int j = i;
                tasks[i] = Task.Run(()=> WriteFile(j));
            }
            Task.WaitAll(tasks);
        }
        public void WriteFile(int files) {
            File.WriteAllText($"file{files.ToString("000")}.txt", "some text");
        }
    }
}
