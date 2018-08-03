using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public abstract class PropertyStrategy
    {
        public abstract void ProcessProperty(ref Product product, XElement property);
    }
}
