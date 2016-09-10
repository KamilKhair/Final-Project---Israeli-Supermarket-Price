using System.Linq;
using System.Xml.Linq;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class RamiLeviAccessor
    {
        internal string GetPriceById(string id)
        {
            var items = XElement.Load(@"D:/ISMC/Data/RamiLevi.xml").Descendants("Item");
            var item = items.Single(p =>
            {
                var xElement = p.Element("ItemCode");
                return xElement != null && xElement.Value.Equals(id);
            });
            return item.Element("ItemPrice")?.Value;
        }
    }
}