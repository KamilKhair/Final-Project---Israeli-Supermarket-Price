using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class MahsaneHashookAccessor
    {
        internal string GetPriceById(string id)
        {
            var items = XElement.Load(@"D:/ISMC/Data/MahsaneHashook.xml");
            var item = items
                .XPathSelectElements("./Products/Product/ItemCode")
                .Where(x => x.Value == id)
                .Select(x => x.Parent);
            return item.ElementAt(0).Element("ItemPrice")?.Value;
        }
    }
}