using System.Xml.Linq;
using Vitacom.XmlParsing.Core.Strategy;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Parser
{
    public class ComplexPropertyParser : IComplexPropertyParser
    {
        private PropertyStrategy _propertyStrategy;
        public ComplexPropertyParser(PropertyStrategy propertyStrategy)
        {
            _propertyStrategy = propertyStrategy;
        }
        public void ParseComplexProperty(ref Product product, XElement property)
        {
            _propertyStrategy.ProcessProperty(ref product, property);
        }
    }
}
