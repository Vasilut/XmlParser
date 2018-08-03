using System;
using System.Collections.Generic;
using System.Text;
using Vitacom.XmlParsing.Model;

namespace Vitacom.XmlParsing.Core.Parser
{
    public interface IXmlParser
    {
        List<Product> ParseXmlDocument(string inputFilePath);
    }
}
