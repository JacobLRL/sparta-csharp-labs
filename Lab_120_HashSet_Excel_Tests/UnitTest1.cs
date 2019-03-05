using NUnit.Framework;
using Lab_120_Hash_Set_To_Excel;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /*
         * Start stopwatch
         * Pass 3 numbers and array
         * double the numbers and pass to a linked list
         * double numbers and put into hash set
         * add 15, treble numberas and pass to dictionary
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
         *  OUTPUT 4 PARAMS
         *  Finally launch excel to read this file using Process.Start
         * 
         * */
        [TestCase(1,2,3,10)]
        public void HashSetToExcel(int a, int b, int c, int d) {
            Custom custom = new HashSetToExcel().HashSetToExcelTest(a,b,c);
            Assert.LessOrEqual(custom.elapsedTime, d);
        }
    }
}