using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class RamiLeviAccessor
    {
        internal string GetPriceById(string id)
        {
            var items = XElement.Load(@"D:/RamiLevi.xml");
            var item = items.Descendants();
            foreach (var client in items
             .XPathSelectElements("./Items/Item/ItemCode")
             .Where(x => x.Value == id)
             .Select(x => x.Parent))
            { }
            return item.ElementAt(0).Element("ItemPrice")?.Value;
        }
    }
}