using System.Linq;
using System.Xml.Linq;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class MahsaneHashookAccessor
    {
        internal string GetPriceById(string id)
        {
            var products = XElement.Load(@"D:/ISMC/Data/MahsaneHashook.xml").Descendants("Product");
            var product = products.Single(p =>
            {
                var xElement = p.Element("ItemCode");
                return xElement != null && xElement.Value.Equals(id);
            });
            return product.Element("ItemPrice")?.Value;
        }
    }
}