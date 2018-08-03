using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    abstract class PropertyStrategy
    {
        public abstract void ProcessProperty(Product product, XElement property);
    }
}
