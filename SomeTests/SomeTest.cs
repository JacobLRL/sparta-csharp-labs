using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    public class SomeTest
    {
        // takes a string change any text into lowercase then uppercase on repeat, ignoring spaces
        public string TextToSpongeBobMeme(string str) {
            return "";
        }

        // takes 3 words, return a string removing the middle word leaving one space
        public string RemoveMiddleWord(string str) {
            return "";
        }

        // takes an array of ints, return the sum of the array NOT INCLUDING THE LARGEST NUMBER
        public int SumIgnoringMax(int[] intArr) {
            return -1;
        }

        // takes 2 ints which decides how high the pyramid goes
        /*example for 5, 9
             *
            ***
           *****
          *******
         *********
         */
        public char[,] Pyramid(int height, int width) {
            char[,] pyramid = new char[height, width];
            //some code to make it work, good luck 
            bool b = false;
            int count = 0;
            for (int i = 0; i < pyramid.GetLength(0); i++)
            {
                for (int j = 0; j < pyramid.GetLength(1); j++)
                {
                    if ((pyramid.GetLength(1) / 2 - i) == j || b)
                    {
                        b = true;
                        pyramid[i, j] = '*';
                        count++;
                        if (count == 2 * i + 1)
                        {
                            b = false;
                            count = 0;
                        }
                    }
                    else
                    {
                        pyramid[i, j] = ' ';
                    }
                }
            }
            
            return pyramid;
        }
    }
}
