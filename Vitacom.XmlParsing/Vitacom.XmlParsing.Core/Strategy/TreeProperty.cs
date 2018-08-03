using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Vitacom.XmlParsing.Model;
using Vitacom.XmlParsing.Model.Model;

namespace Vitacom.XmlParsing.Core.Strategy
{
    public class TreeProperty : PropertyStrategy
    {
        private List<Tree> _treeList;

        public TreeProperty()
        {
            _treeList = new List<Tree>();
        }
        public override void ProcessProperty(ref Product product, XElement property)
        {
            foreach (var item in property.Descendants())
            {
                var tree = new Tree();
                tree.Depth = item.Attribute("depth")?.Value;
                tree.Id = item.Attribute("id")?.Value;
                tree.TreeValue = item.Value;

                _treeList.Add(tree);
            }
            product.Trees = _treeList;
        }
    }
}
