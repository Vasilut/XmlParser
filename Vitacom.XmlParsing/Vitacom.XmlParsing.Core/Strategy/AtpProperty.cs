using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class AtpProperty : PropertyStrategy
    {
        public AtpProperty()
        {

        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            var atp = new Atp();
            foreach (var item in property.Descendants())
            {
                if(item.Name.LocalName == "nextExpectedStockDateLocal")
                {
                    atp.NextExpectedStockLocal = item.Value;
                }
                else
                if(item.Name.LocalName == "nextExpectedStockDateCentral")
                {
                    atp.NextExpectedStockCentral = item.Value;
                }
            }
            //product.Atp = atp;
        }
    }
}
