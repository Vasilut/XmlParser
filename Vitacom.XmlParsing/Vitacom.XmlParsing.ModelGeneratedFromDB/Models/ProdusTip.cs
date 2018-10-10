using System;
using System.Collections.Generic;

namespace Vitacom.XmlParsing.ModelGeneratedFromDB.Models
{
    public partial class ProdusTip
    {
        public ProdusTip()
        {
            Produs = new HashSet<Produs>();
        }

        public decimal Id { get; set; }
        public string Descriere { get; set; }
        public int? Version { get; set; }

        public ICollection<Produs> Produs { get; set; }
    }
}
