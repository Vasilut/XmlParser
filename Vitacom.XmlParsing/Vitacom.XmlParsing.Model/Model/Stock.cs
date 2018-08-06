using System;
using System.Collections.Generic;
using System.Text;

namespace Vitacom.XmlParsing.Model.Model
{
    public class Stock
    {
        public string InStockLocal { get; set; }
        public string InStockCentral { get; set; }
        public Atp Atp { get; set; }
    }
}
