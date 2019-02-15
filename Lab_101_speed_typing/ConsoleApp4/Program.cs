using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyping
{
    class Program
    {
        public static int time = 0;
        public static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Console.WriteLine("How long would you like to enter characters?");
            time = int.Parse(Console.ReadLine());
            Console.WriteLine("You have selected " + time + " seconds");
            Console.WriteLine("What mode would you like, alphabetical or random");
            string mode = Console.ReadLine();
            Console.WriteLine("press enter key to begin!");
            Console.ReadLine();
            DateTime now = DateTime.Now;
            DateTime finish = now.AddSeconds(time);
            string answer = "";
            string ans = "";
            if (mode == "alphabetical")
            {
                ans = Alpha(answer, finish);
            }
            else
            {
                ans = Rand(answer, finish);
            }
            Console.WriteLine("\nTimes up");
            Console.WriteLine($"What you typed: {ans}");
            Console.WriteLine($"Score: {ans.Length}");
            Console.Read();
        }

        public static string Alpha(string answer, DateTime finish) {
            while (true)
            {
                foreach (var elem in alphabet)
                {
                    bool gate = true;
                    while (gate)
                    {
                        if (Console.ReadKey().KeyChar == elem)
                        {
                            answer += elem;
                            gate = false;
                        }
                        else {
                            Console.WriteLine("\nWrong!");
                        }
                        if (DateTime.Compare(DateTime.Now, finish) >= 0) break;
                    }
                    if (DateTime.Compare(DateTime.Now, finish) >= 0) break;
                }
                if (DateTime.Compare(DateTime.Now, finish) >= 0) break;
            }
            return answer;
        }

        public static string Rand(string answer, DateTime finish) {
            while (true)
            {
                answer += Console.ReadKey().KeyChar;
                if (DateTime.Compare(DateTime.Now, finish) >= 0) break;
            }
            return answer;
        } 
    }
}
