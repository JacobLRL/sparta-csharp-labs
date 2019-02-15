using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyping
{
    class Program
    {
        private static int time = 0;
        public static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Console.WriteLine("How long would you like to enter characters?");
            int sec = int.Parse(Console.ReadLine());
            SetTime(sec);
            Console.WriteLine("You have selected " + time + " seconds");
            Console.WriteLine("What mode would you like, alphabetical or random");
            string mode = Console.ReadLine();
            Console.WriteLine("press enter key to begin!");
            Console.ReadLine();
            DateTime now = DateTime.Now;
            DateTime finish = now.AddSeconds(sec);
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
            Console.WriteLine("");
            Console.WriteLine("Times up");
            Console.WriteLine(ans);
            Console.WriteLine(ans.Length);
            Console.Read();
        }

        public static void SetTime(int seconds) {
            time = seconds;
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
