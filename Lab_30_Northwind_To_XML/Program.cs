using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Lab_30_Northwind_To_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            using (var db = new Northwind())
            {
                products = db.Products.Take(3).ToList();
            }
            //products.ForEach(elem => Console.WriteLine(elem.ProductName));
            var xml = new XElement("Products",
                from p in products
                select new XElement("Product",
                new XAttribute("ProductID", p.ProductID),
                new XAttribute("Cost", p.Cost),
                new XAttribute("ProductName", p.ProductName)
                ));
            Console.WriteLine(xml.ToString());
            var doc = new XDocument(xml);
            doc.Save("Products.xml");
            //read data
            Console.WriteLine(Environment.NewLine + "now to read data" + Environment.NewLine);
            Console.WriteLine(File.ReadAllText("Products.xml"));
            var serializer = new XmlSerializer(typeof(Products));
            
        }
    }

    [XmlRoot("Products")]
    public class Products {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
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
        public virtual Category Category { get; set; }
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
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
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
}
