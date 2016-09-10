using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class ShopersalAccessor
    {
        internal string GetPriceById(string id)
        {
            var items = XElement.Load(@"D:/ISMC/Data/Shopersal.xml").Descendants("Item");
            var item = items.Single(p =>
            {
                var xElement = p.Element("ItemCode");
                return xElement != null && xElement.Value.Equals(id);
            });
            return item.Element("ItemPrice")?.Value;
        }
    }
}