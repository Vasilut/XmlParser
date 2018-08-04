using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class PropertiesProperty : PropertyStrategy
    {
        private List<Properties> _propertiList;

        public PropertiesProperty()
        {
            _propertiList = new List<Properties>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            foreach (var item in property.Descendants())
            {
                var propertyNew = new Properties();
                propertyNew.Id = item.Attribute("id")?.Value;
                propertyNew.MultiplierId = item.Attribute("multiplierID")?.Value;
                propertyNew.UnitId = item.Attribute("unitID")?.Value;
                propertyNew.ValueId = item.Attribute("valueID")?.Value;
                propertyNew.PropertiValue = item.Value;
                _propertiList.Add(propertyNew);
            }
            product.Properties = _propertiList;
        }
    }
}
