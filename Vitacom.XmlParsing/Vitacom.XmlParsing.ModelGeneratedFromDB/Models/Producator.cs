using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class Producator
    {
        public Producator()
        {
            Produs = new HashSet<Produs>();
        }

        public decimal Id { get; set; }
        public string Descriere { get; set; }
        public string Nume { get; set; }
        public int? PartenerId { get; set; }
        public int? Version { get; set; }
        public decimal? IdTara { get; set; }

        public Tara IdTaraNavigation { get; set; }
        public ICollection<Produs> Produs { get; set; }
    }
}
