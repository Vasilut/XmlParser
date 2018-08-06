using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class PriceProperty : PropertyStrategy
    {
        private List<Price> _priceList;

        public PriceProperty()
        {
            _priceList = new List<Price>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            //we have next structure
            /*
                         * <priceLevels>
                    <normalPricing from="2017-02-13" to="2018-07-18">
                 <price level="1" moq="1" currency="EUR">61.22</price>
                </normalPricing>
                <specialOfferPricing></specialOfferPricing>
               <goingPriceInclVAT currency="EUR" quantity="1">119.99</goingPriceInclVAT>
               </priceLevels>
             */

            var normalPrice = new NormalPricing();
            normalPrice.From = property.Element("normalPricing").Attribute("from").Value;
            normalPrice.To = property.Element("normalPricing").Attribute("to").Value;

            var firstDescendant = property.Descendants().FirstOrDefault();
            if (firstDescendant != null)
            {
                foreach (var item in firstDescendant.Descendants())
                {
                    var price = new Price();
                    price.Level = item.Attribute("level").Value;
                    price.Moq = item.Attribute("moq").Value;
                    price.Currency = item.Attribute("currency").Value;
                    price.PriceValue = item.Value;
                    _priceList.Add(price);
                }
            }
            normalPrice.Prices = _priceList;
            var specialOfferPricing = new SpecialOfferPricing();
            var goingPriceInclVat = new GoingPriceInclVat();

            foreach (var item in property.Descendants())
            {
                if (item.Name.LocalName == "specialOfferPricing")
                {
                    specialOfferPricing.Value = item.Value;
                }
                else
                if (item.Name.LocalName == "goingPriceInclVAT")
                {
                    goingPriceInclVat.Currency = item.Attribute("currency").Value;
                    goingPriceInclVat.Quantity = item.Attribute("quantity").Value;
                    goingPriceInclVat.Value = item.Value;
                }
            }
            var priceLevel = new PriceLevels();
            priceLevel.GetGoingPriceInclVat = goingPriceInclVat;
            priceLevel.SpecialOfferPricing = specialOfferPricing;
            priceLevel.NormalPricing = normalPrice;
            product.PriceLevel = priceLevel;

        }
    }
}
