using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class Produs
    {
        public Produs()
        {
            FisiereProdus = new HashSet<FisiereProdus>();
        }

        public decimal Id { get; set; }
        public byte? Activ { get; set; }
        public string CodProdus { get; set; }
        public byte? Compus { get; set; }
        public DateTime? Created { get; set; }
        public string Denumire { get; set; }
        public byte? DescriereAmbalaj { get; set; }
        public byte? DescriereRom { get; set; }
        public byte? Erp { get; set; }
        public byte? FransizaClienti { get; set; }
        public byte? FransizaVitacom { get; set; }
        public int? Garantie { get; set; }
        public int? GarantieClient { get; set; }
        public byte? Kan { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? NextReceptieDate { get; set; }
        public int? NextReceptieQty { get; set; }
        public byte? NonVandabil { get; set; }
        public byte? Preorder { get; set; }
        public byte? SerieIndividuala { get; set; }
        public byte? Sfa { get; set; }
        public byte? Stocabil { get; set; }
        public byte? ValidErp { get; set; }
        public byte? ValidWeb { get; set; }
        public int? Version { get; set; }
        public byte? Web1 { get; set; }
        public byte? Web2 { get; set; }
        public byte? Web3 { get; set; }
        public byte? Wms { get; set; }
        public decimal? IdBrand { get; set; }
        public decimal? IdCodVamal { get; set; }
        public decimal? IdCotaTva { get; set; }
        public decimal? IdProducator { get; set; }
        public decimal? IdProprietateGrup { get; set; }
        public decimal? IdTara { get; set; }
        public decimal? IdTipProdus { get; set; }
        public int? BestBuy { get; set; }
        public double? EpMinMargin { get; set; }
        public byte? IsEprice { get; set; }
        public byte? Wsf { get; set; }

        public Brand IdBrandNavigation { get; set; }
        public CotaTva IdCotaTvaNavigation { get; set; }
        public Producator IdProducatorNavigation { get; set; }
        public ProprietateGrup IdProprietateGrupNavigation { get; set; }
        public Tara IdTaraNavigation { get; set; }
        public ProdusTip IdTipProdusNavigation { get; set; }
        public ICollection<FisiereProdus> FisiereProdus { get; set; }
    }
}
