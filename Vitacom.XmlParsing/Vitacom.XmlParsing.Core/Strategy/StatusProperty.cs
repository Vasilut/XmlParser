using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class StatusProperty : PropertyStrategy
    {
        private List<Status> _statusList;

        public StatusProperty()
        {
            _statusList = new List<Status>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            foreach (var item in property.Descendants())
            {
                var status = new Status();
                status.StatusAttribute = item.Attribute("status")?.Value;
                status.Value = item.Value;
                _statusList.Add(status);
            }
            product.Statuses = _statusList;
        }
    }
}
