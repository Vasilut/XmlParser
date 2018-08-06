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
            Attachments = new List<Attachment>();
            Trees = new List<Tree>();
            Properties = new List<Properties>();
            Statuses = new List<Status>();
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
        public string IntroductionDate { get; set; }
        public string SerialnumberKeeping { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Tree> Trees { get; set; }
        public List<Properties> Properties { get; set; }
        public List<Status> Statuses { get; set; }
        public PriceLevels PriceLevel { get; set; }
        public Stock Stock { get; set; }
    }
}
