using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04_Array
{
    public class Array
    {
        public int CreateArray() {
            return -1;
        }

        public int SumOfSquares(int num) {
            int sum = 0;
            for (int i = 1; i <= num; i++) {
                sum += (i * i);
            }
            return sum;
        }
    }
}
