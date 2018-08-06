using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class StockProperty : PropertyStrategy
    {
        public override void ProcessProperty(ref Product product, XElement property)
        {
            var stock = new Stock();
            var atp = new Atp();

            foreach (var item in property.Descendants())
            {
                if (item.Name.LocalName == "inStockLocal")
                {
                    stock.InStockLocal = item.Value;
                }
                else
                if (item.Name.LocalName == "inStockCentral")
                {
                    stock.InStockCentral = item.Value;
                }
                else
                if (item.Name.LocalName == "nextExpectedStockDateLocal")
                {
                    atp.NextExpectedStockLocal = item.Value;
                }
                else
                if (item.Name.LocalName == "nextExpectedStockDateCentral")
                {
                    atp.NextExpectedStockCentral = item.Value;
                }
            }
            stock.Atp = atp;
            product.Stock = stock;
        }
    }
}
