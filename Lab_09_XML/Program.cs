using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;//must be used for xml
using System.IO;
using System.Xml;

namespace Lab_09_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nMost Basic XML Element\n");

            var xml01 = new XElement("test", 1);//test field name 1 is data
            Console.WriteLine(xml01);

            Console.WriteLine("\nNow add a sub element\n");
            var xml02 = new XElement("RootElem",
                new XElement("SubElement", 100)
                );
            Console.WriteLine(xml02);

            Console.WriteLine("\nNow add multiple sub elements\n");
            var xml03 = new XElement("RootElem",
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100)
                );
            Console.WriteLine(xml03);

            Console.WriteLine("\nNow add an attribute\n");
            var xml04 = new XElement("RootElem",
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100)
                );
            Console.WriteLine(xml04);

            Console.WriteLine("\nNow add attributes to all\n");
            var xml05 = new XElement("RootElem",
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100)                
                );
            Console.WriteLine(xml05);

            Console.WriteLine("\nNow save to a document\n");
            var xml06 = new XElement("RootElem",
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100),
                new XElement("SubElement", new XAttribute("Height", 200), 100)                
                );
            Console.WriteLine(xml06);
            // xDocument : save this to file
            //var doc06 = new XDocument(XElement.Parse(xml06.ToString()));
            //doc06.Save("Xml06.xml");

            Console.WriteLine("\nreading and writing xml\n");
            XDocument doc07 = XDocument.Load("Xml06.xml");
            Console.WriteLine(doc07);
            Console.Read();
        }
    }
}
