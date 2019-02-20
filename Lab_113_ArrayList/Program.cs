using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_113_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            arrayList arr = new arrayList();
            arr.arrayListMethod(10,20,30,40);
        }
    }

    public class arrayList {
        public static int[] intArr = new int[4];
        public static Queue<int> queue = new Queue<int>();
        public static Stack<int> stack = new Stack<int>();
        public static Dictionary<int, int> dict = new Dictionary<int, int>();
        public static ArrayList arrList = new ArrayList();
        public int arrayListMethod(int a, int b, int c, int d) {
            // accept 4 ints
            /*
             * put to Array
             * extract, double put to queue
             * extract, double put to stack
             * extract, square put to dictionary
             * put to ARRAYLIST
             * extract and get the sum of the items and return this sum
             
             */
            intArr[0] = a;
            intArr[1] = b;
            intArr[2] = c;
            intArr[3] = d;
            int total = 0;
            Console.WriteLine("Array");
            Console.WriteLine($"{a}, {b}, {c}, {d}");
            Console.WriteLine("Queue");
            ToQueue();
            Console.WriteLine("Stack");
            ToStack();
            Console.WriteLine("Dictionary");
            ToDict();
            Console.WriteLine("Arraylist");
            ToArrayList();
            Console.WriteLine("Total");
            foreach (var elem in arrList) {
                total += (int)elem;
            }
            Console.WriteLine(total);

            return total;
        }

        public void ToQueue() {
            foreach (var elem in intArr) {
                queue.Enqueue(elem*2);
                Console.WriteLine(elem*2);
            }
        }

        public void ToStack()
        {
            for (int i = 0; i < 4; i++)
            {
                int num = queue.Dequeue();
                Console.WriteLine(num*2);
                stack.Push(num*2);
            }
        }

        public void ToDict() {
            dict.Clear();
            for (int i = 0; i < 4; i++) {
                int num = stack.Pop();
                Console.WriteLine(num);
                dict.Add(i, num*num);
            }
        }

        public void ToArrayList() {
            arrList.Clear();
            foreach (var elem in dict) {
                Console.WriteLine(dict[elem.Key]);
                arrList.Add(dict[elem.Key]);
            }
        }
    }
}
