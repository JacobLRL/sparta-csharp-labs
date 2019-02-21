using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab_10_Entity
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            
            using (var db = new NorthwindEntities()) {
                //customers list =  (read from northwind).
                //                  (pull out all customers)
                //                  (send to list of customers)
                customers = db.Customers.ToList<Customer>();
            }
            // created list outside because list can be used here
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.ContactName} has ID {customer.CustomerID} from {customer.City}");
            }

            // CRUD

            // SELECT one customer
            using (var db = new NorthwindEntities()) {
                //linq query : Mocrosoft : Language independent query
                Customer customerToUpdate =
                    // select all custommers in northwind
                    (from Customer in db.Customers
                         // choose one where ID matches
                     where Customer.CustomerID == "ALFKI"
                     //output the one selected
                     select Customer).FirstOrDefault();
                Console.WriteLine("\n\nFinding one customer\n");
                Console.WriteLine($"{customerToUpdate.ContactName} and id {customerToUpdate.CustomerID}");
            }

            // SELECT one customer with lambda function
            using (var db = new NorthwindEntities())
            {
                //linq query : Microsoft : Language independent query
                Customer customerToUpdate =
                    db.Customers.Where(c => c.CustomerID == "ALFKI").FirstOrDefault();
                Console.WriteLine("\n\nFinding one customer with lambda function\n");
                Console.WriteLine($"{customerToUpdate.ContactName} and id {customerToUpdate.CustomerID}");

                //update customer
                //customerToUpdate.ContactName = "yeet yeet";
                // update db permenently
                db.SaveChanges();
            }

            // inserting
            using (var db = new NorthwindEntities()) {
                var customerToCreate = new Customer
                {
                    CustomerID = "PHIL1",
                    ContactName = "Great Name",
                    City = "Some Town",
                    CompanyName = "Yeet"
                };
                // adding customer to local db
                db.Customers.Add(customerToCreate);
                // write changes permanently to real db
                db.SaveChanges();

            }
            DisplayAll();
            Console.WriteLine("\n\n");
            // deleting
            using (var db = new NorthwindEntities()) {
                var customerToDelete = db.Customers.Where(c => c.CustomerID == "PHIL1").FirstOrDefault();
                try
                {
                    db.Customers.Remove(customerToDelete);
                    db.SaveChanges();
                }
                catch { }
                    
            }
            DisplayAll();
        }

        public static void DisplayAll() {

            using (var db = new NorthwindEntities())
            {
                //customers list =  (read from northwind).
                //                  (pull out all customers)
                //                  (send to list of customers)
                customers = db.Customers.ToList<Customer>();
            }
            // created list outside because list can be used here
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.ContactName} has ID {customer.CustomerID} from {customer.City}");
            }
        }

    }
}
