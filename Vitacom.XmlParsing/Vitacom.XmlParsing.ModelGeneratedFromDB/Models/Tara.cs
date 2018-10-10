using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class Tara
    {
        public Tara()
        {
            Producator = new HashSet<Producator>();
            Produs = new HashSet<Produs>();
        }

        public decimal Id { get; set; }
        public string Cod { get; set; }
        public string Denumire { get; set; }
        public byte? Isue { get; set; }
        public int? Version { get; set; }

        public ICollection<Producator> Producator { get; set; }
        public ICollection<Produs> Produs { get; set; }
    }
}
