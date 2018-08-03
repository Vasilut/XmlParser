using System;
using System.Linq;
using System.Xml.Linq;

namespace Vitacom.XmlParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load(@"D:\download\nedis_catalog_2018-07-18_en_US_58960_v1-0_xml.xml\nedis_catalog_2018-07-18_en_US_58960_v1-0_xml.xml");

            var productList = from prod in document.Descendants("product") select prod;
            foreach (var item in productList)
            {
                foreach (var descendant in item.Descendants())
                {
                    if(descendant.HasElements)
                    {

                    }
                }
            }
            Console.WriteLine("Hello World!");
            var x = 2;
            Console.ReadLine();
        }
    }
}
