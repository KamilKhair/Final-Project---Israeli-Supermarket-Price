using System;
using System.CodeDom;
using System.Text;
using System.Xml;
using IsraeliSuperMarketManager;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new SuperMarketManager();
            GetProducts(manager);
            //Test();
            //ComparePrces(manager);
            Console.Read();
        }

        private static void Test()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:/Products.xml");
            if (xmlDocument.DocumentElement == null) return;
            var products = new Product[xmlDocument.DocumentElement.ChildNodes.Count];
            var i = 0;
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Attributes != null)
                {
                    products[i++] = new Product
                    {
                        Id = int.Parse(node.Attributes["Id"].InnerText),
                        Name = node.Attributes["Name"].InnerText
                    };
                }
            }
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

        }

        private static async void GetProducts(ISuperMarketManager manager)
        {
            var resultObject = await manager.GetProductsAsync();
            Console.WriteLine(resultObject.Length);
            foreach (var product in resultObject)
            {
                Console.WriteLine(product);
            }
        }

        private static async void ComparePrces(ISuperMarketManager manager)
        {
            var resultObject = await manager.ComparePricesAsync(new[]
            {
                new Product {Id = 1, Name = "111"},
                new Product {Id = 2, Name = "222"},  
                new Product {Id = 3, Name = "333"}, 
            });
            foreach (var product in resultObject)
            {
                Console.WriteLine(product);
            }
        }
    }
}
