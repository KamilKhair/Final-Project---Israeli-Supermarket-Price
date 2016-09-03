using System.Linq;
using System.Xml.Linq;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class MahsaneHashookAccessor
    {
        internal string GetPriceById(string id)
        {
            var items = XElement.Load(@"D:/MahsaneHashook.xml");
            var item =
            from itemCodeElement in items.Elements().Elements("ItemCode")
            where (string)itemCodeElement.Value == id
            select itemCodeElement.Parent?.Element("ItemPrice");
            return item.ElementAt(0).Element("ItemPrice")?.Value;
        }
    }
}