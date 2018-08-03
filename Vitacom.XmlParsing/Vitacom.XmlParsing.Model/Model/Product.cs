using System;
using System.Collections.Generic;
using System.Text;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Model
{
    public class Product
    {
        public Product()
        {
            Images = new List<Image>();
        }
        public string NedisPartnr { get; set; }
        public string NedisArtId { get; set; }
        public string VendorPartnr { get; set; }
        public string Brand { get; set; }
        public string Ean { get; set; }
        public string InstraStatCode { get; set; }
        public string Unspsc { get; set; }
        public string HeaderText { get; set; }
        public string InternetText { get; set; }
        public string GeneralText { get; set; }
        public List<Image> Images { get; set; }

    }
}
