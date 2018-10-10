using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class CotaTva
    {
        public CotaTva()
        {
            Produs = new HashSet<Produs>();
        }

        public decimal Id { get; set; }
        public double Cota { get; set; }
        public string Descriere { get; set; }
        public int? Version { get; set; }

        public ICollection<Produs> Produs { get; set; }
    }
}
