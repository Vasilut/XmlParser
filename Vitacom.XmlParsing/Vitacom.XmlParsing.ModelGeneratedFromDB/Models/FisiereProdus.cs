using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class FisiereProdus
    {
        public decimal Id { get; set; }
        public string Filename { get; set; }
        public int SortOrder { get; set; }
        public int? Version { get; set; }
        public decimal? IdFisFileLink { get; set; }
        public decimal? IdFisFileType { get; set; }
        public decimal? IdFisImageType { get; set; }
        public decimal? IdProdus { get; set; }
        public decimal? IdFisDocType { get; set; }
        public byte? Validat { get; set; }
        public int? ValabilWeb { get; set; }
        public int? New { get; set; }
        public byte? Oferta { get; set; }
        public int? Catalog { get; set; }

        public Produs IdProdusNavigation { get; set; }
    }
}
