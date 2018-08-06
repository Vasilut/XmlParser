using System;
using System.Collections.Generic;
using System.Text;

namespace Vitacom.XmlParsing.Model.Model
{
    public class PriceLevels
    {
        public NormalPricing NormalPricing {get;set;}
        public SpecialOfferPricing SpecialOfferPricing { get; set; }
        public GoingPriceInclVat GetGoingPriceInclVat { get; set; }
    }
}
