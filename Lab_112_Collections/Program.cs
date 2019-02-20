using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_112_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Collections();
            //instance.Collections20MinLab(2,3,4);
        }
    }

    public class Collections {
        /* receive 3 numbers 
         * put into array
         * output numbers, double each one and store in a stack
         * Repeat ie output numbers, double and store in a queue
         * output numbers, square them then store in List<int>
         * Add up numbers in the List<int> and return the total
         * 
         */
        public static int[] intArr = new int[3];
        public static Stack<int> stack = new Stack<int>();
        public static Queue<int> queue = new Queue<int>();
        public static List<int> list = new List<int>();
        public int Collections20MinLab(int num1, int num2, int num3) {
            intArr[0] = num1;
            intArr[1] = num2;
            intArr[2] = num3;
            Console.WriteLine("int array");
            foreach (var elem in intArr) {
                Console.WriteLine(elem);
                stack.Push(elem*2);
            }
            Console.WriteLine("Stack");
            for (int i = 0; i < 3; i++) {
                int item = stack.Pop();
                Console.WriteLine(item);
                queue.Enqueue(item*2);
            }
            Console.WriteLine("Queue");
            list.Clear();
            for (int i = 0; i < 3; i++)
            {
                int item = queue.Dequeue();
                Console.WriteLine(item);
                list.Add(item*item);
            }
            int sum = 0;
            Console.WriteLine("List");
            foreach (var elem in list) {
                Console.WriteLine(elem);
                sum += elem;
            }
            Console.WriteLine(sum);
            return sum;
        }
    }
}
