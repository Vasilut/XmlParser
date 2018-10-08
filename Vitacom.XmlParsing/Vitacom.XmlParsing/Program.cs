using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Core.Parser;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.ModelGeneratedFromDB.Models;

namespace Vitacom.XmlParsing
{
    
    public class Program
    {
        
        static void Main(string[] args)
        {
            List<Product> productLst = new List<Product>();
            string xmlFilePath = @"D:\vitacom db\nedis_catalog_2018-10-02_en_US_58960_v1-0_xml.xml";
            IXmlParser xmlParser = new XmlParser();
            productLst = xmlParser.ParseXmlDocument(xmlFilePath);


            //XDocument document = XDocument.Load(@"D:\download\nedis_catalog_2018-07-18_en_US_58960_v1-0_xml.xml\fis.xml");

            //var productList = from prod in document.Descendants("product") select prod;
            //foreach (var item in productList)
            //{
            //    //iteram fiecare produs
            //    //luam proprietatile simple
            //    var product = new Product
            //    {
            //        NedisPartnr = item.Element("nedisPartnr").Value,
            //        NedisArtId = item.Element("nedisArtlid").Value,
            //        VendorPartnr = item.Element("vendorPartnr").Value,
            //        Brand = item.Element("brand").Value,
            //        Ean = item.Element("EAN").Value,
            //        InstraStatCode = item.Element("intrastatCode").Value,
            //        Unspsc = item.Element("UNSPSC").Value,
            //        HeaderText = item.Element("headerText").Value,
            //        InternetText = item.Element("internetText").Value,
            //        GeneralText = item.Element("generalText").Value
            //    };

            //    var complexNodes = item.Descendants().Where(node => node.HasElements == true).ToList();
            //    foreach (var descendant in complexNodes)
            //    {
            //        //iteram fiecare proprietate complexa a produsului
            //        if(descendant.Name.LocalName == "images")
            //        {
            //            foreach (var itemj in descendant.Descendants())
            //            {
            //                Console.WriteLine(itemj.Value);
            //                Console.Write(itemj.Attribute("order").Value);
            //                Console.WriteLine(itemj);
            //            }
            //        }
            //        else
            //        if(descendant.Name.LocalName == "categories")
            //        {
            //            var xxl = descendant.Descendants();
            //        }
            //        else
            //        if(descendant.Name.LocalName == "tree")
            //        {
            //            var xxl = descendant.Descendants();
            //        }
            //        else
            //        if(descendant.Name.LocalName == "priceLevels")
            //        {
            //            var xxl = descendant.Descendants();
            //        }
            //    }
            //    productLst.Add(product);
            //}

            StringBuilder response = new StringBuilder();
            using (var db = new VITACOM_CENTRALContext())
            {
                var listOfImages = db.ProductImage.ToList();

                foreach (var item in productLst)
                {
                    
                    var productPictureInDb = listOfImages.Where(prod => prod.NedisArtlid?.ToString() == item.NedisArtId && prod.NedisPartnr == item.NedisPartnr).ToList();
                    if(productPictureInDb == null || productPictureInDb.Count == 0)
                    {
                        response.Append("-----").Append(Environment.NewLine);
                        response.Append($"Product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr} was not found in db").Append(Environment.NewLine);
                        Console.WriteLine($"Product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr} was not found in db");
                        continue;
                    }

                    var listOfPicture = item.Images;
                    foreach (var picture in listOfPicture)
                    {
                        var pictureFound = productPictureInDb.Where(pic => pic.ImageFilename == picture.ImageValue &&
                                                                    pic.ImageOrder.ToString() == picture.Order &&
                                                                    pic.ImageType.ToString() == picture.Type).FirstOrDefault();

                        if(pictureFound == null)
                        {
                            response.Append("-----").Append(Environment.NewLine);
                            response.Append($"Picture with name {picture.ImageValue} from the product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr}  was not found in the db ").
                                     Append(Environment.NewLine);
                            Console.WriteLine($"Picture with name {picture.ImageValue} from the product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr}  was not found in the db ");
                        }
                    }
                }
            }

            using (var file = new StreamWriter("output.txt"))
            {
                file.Write(response.ToString());
            }

            Console.WriteLine("Done!");
            var x = 2;
            Console.ReadLine();
        }
    }
}
