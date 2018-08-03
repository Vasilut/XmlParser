using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class AttachmentProperty : PropertyStrategy
    {
        private List<Attachment> _attachmentList;

        public AttachmentProperty()
        {
            _attachmentList = new List<Attachment>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            foreach (var item in property.Descendants())
            {
                var attachment = new Attachment();
                attachment.Type = item.Attribute("type")?.Value;
                attachment.Description = item.Attribute("description")?.Value;
                attachment.AttachmentValue = item.Value;
                _attachmentList.Add(attachment);
            }

            product.Attachments = _attachmentList;
        }
    }
}
