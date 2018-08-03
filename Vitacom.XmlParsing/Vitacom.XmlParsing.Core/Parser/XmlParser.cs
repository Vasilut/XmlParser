using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Core.Factory;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Parser
{
    public class XmlParser : IXmlParser
    {

        public XmlParser()
        {
        }
        public List<Product> ParseXmlDocument(string inputFilePath)
        {
            List<Product> _productList = new List<Product>();
            XDocument document = XDocument.Load(inputFilePath);

            var productList = from prod in document.Descendants("product") select prod;
            foreach (var item in productList)
            {
                //iteram fiecare produs
                //luam proprietatile simple
                var product = new Product
                {
                    NedisPartnr = item.Element("nedisPartnr").Value,
                    NedisArtId = item.Element("nedisArtlid").Value,
                    VendorPartnr = item.Element("vendorPartnr").Value,
                    Brand = item.Element("brand").Value,
                    Ean = item.Element("EAN").Value,
                    InstraStatCode = item.Element("intrastatCode").Value,
                    Unspsc = item.Element("UNSPSC").Value,
                    HeaderText = item.Element("headerText").Value,
                    InternetText = item.Element("internetText").Value,
                    GeneralText = item.Element("generalText").Value,
                    IntroductionDate = item.Element("introductionDate").Value,
                    SerialnumberKeeping = item.Element("serialnumberKeeping").Value
                };

                var complexNodes = item.Descendants().Where(node => node.HasElements == true).ToList();
                foreach (var descendant in complexNodes)
                {
                    //iteram fiecare proprietate complexa a produsului

                    var propertyInstance = PropertyFactory.GetProperty(descendant.Name.LocalName);
                    if (propertyInstance != null)
                    {
                        var complexPropertyParser = new ComplexPropertyParser(propertyInstance);
                        complexPropertyParser.ParseComplexProperty(ref product, descendant);
                    }
                    
                }
                _productList.Add(product);
            }

            return _productList;
        }
    }
}
