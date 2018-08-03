using System.Collections.Generic;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class ImagesProperty : PropertyStrategy
    {
        private List<Image> _images;

        public ImagesProperty()
        {
            _images = new List<Image>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {

            foreach (var item in property.Descendants())
            {
                var image = new Image();
                image.ImageValue = item.Value;
                image.Order = item.Attribute("order")?.Value;
                image.Type = item.Attribute("type")?.Value;
                _images.Add(image);
            }

            product.Images = _images;
        }
    }
}
