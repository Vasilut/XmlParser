using System;
using System.Collections.Generic;
using System.Text;
using Vitacom.XmlParsing.Core.Strategy;

namespace Vitacom.XmlParsing.Core.Factory
{
    public class PropertyFactory
    {
        public static PropertyStrategy GetProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "images":
                    {
                        return new ImagesProperty();
                    }
                case "attachments":
                    {
                        return new AttachmentProperty();
                    }
                default:
                    break;
            }
            return null;
        }
    }
}
