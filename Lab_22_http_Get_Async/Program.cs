using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Lab_22_http_Get_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            // sync read off http data
            Uri bbc01 = new Uri("http://www.bbc.co.uk");
            Console.WriteLine(bbc01.Host);
            Console.WriteLine(bbc01.Port);

            Uri bbc02 = new Uri("https://www.bbc.co.uk");
            Console.WriteLine(bbc01.Host);
            Console.WriteLine(bbc01.Port);

            // simplest way to read data is with "Web Client"
            var bbcWebClient = new WebClient { Proxy = null };
            bbcWebClient.DownloadFile(bbc01, "bbc-copy.html");
            
            Console.WriteLine(File.ReadAllText("bbc-copy.html"));
        }
    }
}
