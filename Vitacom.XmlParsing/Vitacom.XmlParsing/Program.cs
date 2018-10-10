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
            string xmlFilePath = @"D:\vitacom db\nedis_catalog_2018-10-10_en_US_58960_v1-0_xml.xml";
            IXmlParser xmlParser = new XmlParser();
            productLst = xmlParser.ParseXmlDocument(xmlFilePath);




            /*
            #region VerifXMlFile

            StringBuilder response = new StringBuilder();
            using (var db = new VITACOM_CENTRALContext())
            {
                var listOfImages = db.ProductImage.ToList();

                foreach (var item in productLst)
                {

                    var productPictureInDb = listOfImages.Where(prod => prod.NedisArtlid?.ToString() == item.NedisArtId && prod.NedisPartnr == item.NedisPartnr).ToList();
                    if (productPictureInDb == null || productPictureInDb.Count == 0)
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
                                                                    pic.ImageOrder.ToString() == (picture.Order == string.Empty ? "0" : picture.Order) &&
                                                                    pic.ImageType.ToString() == (picture.Type == string.Empty ? "0" : picture.Type)).FirstOrDefault();

                        if (pictureFound == null)
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

            #endregion
            */

            StringBuilder response = new StringBuilder();
            using (var db = new VITACOM_CENTRALContext())
            {
                foreach (var item in productLst)
                {
                    //iau id-ul din sincr_F1.produs
                    var relationItem = db.SincrF1produs.Where(sp => sp.Nedisartid.ToString() == item.NedisArtId && sp.Nedispartnr == item.NedisPartnr).FirstOrDefault();
                    if(relationItem == null)
                    {
                        response.Append("-----").Append(Environment.NewLine);
                        response.Append($"For product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr} we don't have any relation in the db").Append(Environment.NewLine);
                        Console.WriteLine($"For product with id {item.NedisArtId} and nedisPartnID {item.NedisPartnr} we don't have any relation in the db");
                        continue;
                    }

                    var databaseCentralId = relationItem.IdVc;

                    //vad cate imagini am in tabelul fisiere_produs pt id-ul gasit
                    var allImages = db.FisiereProdus.Where(prod => prod.IdProdus == databaseCentralId)?.ToList();
                    if(allImages == null || allImages.Count == 0)
                    {
                        response.Append("-----").Append(Environment.NewLine);
                        response.Append($"For product with id {databaseCentralId} and nedisid {item.NedisArtId} and nedisPartnID {item.NedisPartnr} we don't have any images in the db").Append(Environment.NewLine);
                        Console.WriteLine($"For product with id {databaseCentralId} and nedisid {item.NedisArtId} and nedisPartnID {item.NedisPartnr} we don't have any images in the db");
                        continue;
                    }

                    var listOfPicturesFromXml = item.Images;
                    foreach (var picture in listOfPicturesFromXml)
                    {
                        //vad cate imagini din xml gasesc
                        var imageFound = allImages.Where(img => img.Filename == picture.ImageValue &&
                                                         img.SortOrder.ToString() == picture.Order &&
                                                         img.IdFisImageType.ToString() == picture.Type).FirstOrDefault();
                        if(imageFound == null)
                        {
                            response.Append("-----").Append(Environment.NewLine);
                            response.Append($"Image with filename {picture.ImageValue} from product id {databaseCentralId} and nedisid {item.NedisArtId} and nedisPartnID {item.NedisPartnr}  was not found in the database").Append(Environment.NewLine);
                            Console.WriteLine($"Image with filename {picture.ImageValue} from product id {databaseCentralId} and nedisid {item.NedisArtId} and nedisPartnID {item.NedisPartnr}  was not found in the database");
                        }
                    }
                }
            }

            using (var file = new StreamWriter("outputpoze.txt"))
            {
                file.Write(response.ToString());
            }

            Console.WriteLine("Done!");
            var x = 2;
            Console.ReadLine();
        }
    }
}
