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
                case "categories":
                    {
                        return new CategoriesProperty();
                    }
                case "tree":
                    {
                        return new TreeProperty();
                    }
                case "properties":
                    {
                        return new PropertiesProperty();
                    }
                case "status":
                    {
                        return new StatusProperty();
                    }
                case "priceLevels":
                    {
                        return new PriceProperty();
                    }
                case "stock":
                    {
                        return new StockProperty();
                    }
                default:
                    break;
            }
            return null;
        }
    }
}
