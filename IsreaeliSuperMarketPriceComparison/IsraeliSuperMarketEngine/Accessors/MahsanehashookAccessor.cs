using System.Linq;
using System.Xml.Linq;

namespace IsraeliSuperMarketEngine.Accessors
{
    internal class MahsaneHashookAccessor
    {
        /*The accessors you have just duplicate the same code, perhaps it is best to create one class
         * This class could alter it's behavior according to the parameters provided in the constructor,
         * Which could be the path to the file
         */
        internal string GetPriceById(string id)
        {
            /*Refrain from using absolute paths- they will not necessarily exist
              Handle exceptions that might propagate from I/O code.
            */
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