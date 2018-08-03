using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Parser
{
    public interface IComplexPropertyParser
    {
        void ParseComplexProperty(ref Product product, XElement property);
    }
}
