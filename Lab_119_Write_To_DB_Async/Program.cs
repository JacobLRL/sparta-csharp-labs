using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_119_Write_To_DB_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            var something = new WriteToDBAsync();
            var s = new Stopwatch();
            s.Start();
            something.ChangeName(1000);
            s.Stop();
            Console.WriteLine($"Time taken (ms): {s.ElapsedMilliseconds}");
        }
    }

    public class WriteToDBAsync {

        public void ChangeName(int numChanges) {
            var tasks = new Task[numChanges];
            for (int i = 0; i < numChanges; i++) {
                int j = i;
                tasks[j] = Task.Run(() => DBConnection(j));
            }
            Task.WaitAll(tasks);
        }

        public void DBConnection(int number) {
            using (var db = new NorthwindEntities()) {
                Customer customer = new Customer();
                customer = db.Customers.Where(c => c.CustomerID == "ALFKI").FirstOrDefault();
                customer.ContactName = $"Person {number}";
                Console.WriteLine(customer.ContactName);
                db.SaveChanges();
            }
        }
    }
}
