using System.Collections.Generic;

namespace Vitacom.XmlParsing.Model.Model
{
    public class NormalPricing
    {
        public NormalPricing()
        {
            Prices = new List<Price>();
        }
        public string From { get; set; }
        public string To { get; set; }
        public List<Price> Prices { get; set; }
    }
}