using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_104_collections
{
    class Program
    {
        public static int[] myArr = new int[10];
        public static List<int> myList = new List<int>();
        public static Stack<int> myStack = new Stack<int>();
        public static Queue<int> myQueue = new Queue<int>();
        public static Dictionary<int, int> myDict = new Dictionary<int,int>();
        static void Main(string[] args)
        {
            // 10 numbers in an array
            PhilArray();
            // move items to a list and add 1
            AddOneToList();
            // move to stack and add 1
            AddOneToStack();
            // move to queue and add 1
            AddOneToQueue();
            // move to dictionary and add 1
            AddOneToDict();
            // Return total of items in dictionary
            Console.WriteLine(Total());
            Console.Read();

        }

        static void PhilArray() {
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = i + 1;
            }
        }
        static void AddOneToList() {
            foreach (var item in myArr)
            {
                myList.Add(item+1);
            }
        }
        static void AddOneToStack() {
            foreach (var item in myList)
            {
                myStack.Push(item + 1);
            }
        }
        static void AddOneToQueue()
        {
            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(myStack.Pop() +1);
            }
        }
        static void AddOneToDict()
        {
            for (int i = 0; i < 10; i++)
            {
                myDict.Add(i, myQueue.Dequeue()+1);
            }
        }
        static int Total() {
            int total = 0;
            foreach (var item in myDict)
            {
                total += myDict[item.Key];
            }
            return total;
        }
    }
}
