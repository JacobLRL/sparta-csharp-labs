using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Entity_09_LINQ_to_XML
{
    class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            QueryingCategories();
        }
        static void QueryingCategories()
        {


            // read northwind
            using (var db = new Northwind())
            {
                products = db.Products.OrderBy(p => p.ProductName).Take(3).ToList();
            }

            products.ForEach(p => Console.WriteLine(p.ProductName));

            // extract Products

            Console.WriteLine("\n\nExtracting To XML\n\n");

            var xml3 = new XElement("Products",
                from p in products
                select new XElement("Product",
                new XElement("ProductID", p.ProductID),
                new XElement("Cost", p.Cost),
                new XElement("ProductName", p.ProductName),
                                    new XElement("Discontinued", false)
                ));
            // Write to XML
            Console.WriteLine(xml3.ToString());
            // Write to File
            var doc3 = new XDocument(xml3);
            doc3.Save("Products.xml");


            // now the test

            Console.WriteLine("\n\nFirstly just read back the raw XML data as a string\n\n");

            Console.WriteLine(File.ReadAllText("Products.xml"));

            // as XML document

            var doc4 = XDocument.Load("Products.xml");


            Console.WriteLine("\n\nNow let's deserialize back into products\n");
            // create a collection to hold our data
            var products4 = new Products();
            // stream our data back in from file
            using (StreamReader reader = new StreamReader("Products.xml"))
            {
                // create the serializer                
                XmlSerializer serializer = new XmlSerializer(typeof(Products));
                // serialize the product list to a collection 
                products4 = (Products)serializer.Deserialize(reader);
            }

            foreach (Product p in products4.ProductList)
            {
                Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-50}{p.Cost}");
            }



        }  // static void QueryingCategories()


    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }
    }
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../../../../data/Northwind.db");
            // use SQLite
            optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            // install nuget microsoft.entityframeworkcore.sqlserver -projectname entity_09_linq_to_xml
            // optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            // filter out discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }

    }

    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
    }


}