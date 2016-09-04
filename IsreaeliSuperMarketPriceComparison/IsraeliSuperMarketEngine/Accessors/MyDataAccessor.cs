using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using IsraeliSuperMarketEngine.Extensions;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketEngine.Accessors
{
    public class MyDataAccessor
    {
        private RamiLeviAccessor _ramiLeviAccessor;
        private RamiLeviAccessor RamiLeviAccessor => _ramiLeviAccessor ?? (_ramiLeviAccessor = new RamiLeviAccessor());
        private MahsaneHashookAccessor _mahsanehashookAccessor;
        private MahsaneHashookAccessor MahsanehashookAccessor => _mahsanehashookAccessor ?? (_mahsanehashookAccessor = new MahsaneHashookAccessor());
        private ShopersalAccessor _shopersalAccessor;
        private ShopersalAccessor ShopersalAccessor => _shopersalAccessor ?? (_shopersalAccessor = new ShopersalAccessor());
        public Product[] GetProducts()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:/Products.xml");
            if (xmlDocument.DocumentElement == null)
            {
                return null;
            }
            var products = new Product[xmlDocument.DocumentElement.ChildNodes.Count];
            var i = 0;
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Attributes != null)
                {
                    products[i++] = new Product
                    {
                        Id = int.Parse(node.Attributes["Id"].InnerText),
                        Name = node.Attributes["Name"].InnerText,
                        Manufacturer = node.Attributes["Manufacturer"].InnerText,
                        IsWeighted = node.Attributes["IsWeighted"].InnerText == "true"
                    };
                }
            }
            return products;
        }

        public Product GetProduct(string productId)
        {
            var products = XElement.Load(@"D:/Products.xml");
            var product = products.Elements("Product").Single(element => element.Attribute("Id").Value == productId);
            return new Product
            {
                Id = int.Parse(productId),
                Name = product.Attribute("Name").Value,
                Manufacturer = product.Attribute("Manufacturer").Value,
            };
        }

        public Chain[] GetChains()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:/Chains.xml");
            if (xmlDocument.DocumentElement == null)
            {
                return null;
            }
            var chains = new Chain[xmlDocument.DocumentElement.ChildNodes.Count];
            var i = 0;
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Attributes != null)
                {
                    chains[i++] = new Chain
                    {
                        Id = int.Parse(node.Attributes["Id"].InnerText),
                        Name = node.Attributes["Name"].InnerText,
                        Max3Products = null,
                        Min3Products = null
                    };
                }
            }
            return chains;
        }

        public string GetImage(int imageId)
        {
            Bitmap image;
            try
            {
                var imagePath = @"D:\pictures\" + imageId + ".bmp";
                image = (Bitmap) Image.FromFile(imagePath, true);
            }
            catch(Exception)
            {
                return null;
            }
            return image.ToBase64String(ImageFormat.Bmp);
        }

        public Tuple<Chain[], string[]> ComparePrices(Product[] products)
        {
            var catalog = XElement.Load(@"D:/Products.xml");
            var ramiLeviPrices = new List<Product>();
            var mahsaneHashookPrices = new List<Product>();
            var shopersalPrices = new List<Product>();
            var i = 0;
            foreach (var product in products.AsParallel())
            {
                var productElement =
                    catalog.Elements("Product").Single(el => el.Attribute("Id").Value == product.Id.ToString());
                var isComparable = productElement.Attribute("IsComparable").Value == "true";
                if (isComparable)
                {
                    var comparableSearchId = productElement.Attribute("SearchId").Value;

                    //RamiLevi
                    var ramiLeviPrice = double.Parse(RamiLeviAccessor.GetPriceById(comparableSearchId))* product.Quantity;
                    ramiLeviPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = ramiLeviPrice, Quantity = product.Quantity });
                    //MahsaneHashook
                    var mahsaneHashookPrice = double.Parse(MahsanehashookAccessor.GetPriceById(comparableSearchId)) * product.Quantity;
                    mahsaneHashookPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = mahsaneHashookPrice, Quantity = product.Quantity });
                    //ShoperSal
                    var shopersalPrice = double.Parse(ShopersalAccessor.GetPriceById(comparableSearchId)) * product.Quantity;
                    shopersalPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = shopersalPrice, Quantity = product.Quantity });
                }
                else
                {
                    var chains = productElement.Elements("Chain").ToList();
                    var ramiLeviId = chains.Single(el => el.Attribute("Name").Value == "RamiLevi").Attribute("SearchId").Value;
                    var mahsanehashookId = chains.Single(el => el.Attribute("Name").Value == "MahsaneHashook").Attribute("SearchId").Value;
                    var shopersalId = chains.Single(el => el.Attribute("Name").Value == "Shopersal").Attribute("SearchId").Value;

                    //RamiLevi
                    var ramiLeviPrice = double.Parse(RamiLeviAccessor.GetPriceById(ramiLeviId)) * product.Quantity;
                    ramiLeviPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = ramiLeviPrice, Quantity = product.Quantity });
                    //MahsaneHashook
                    var mahsaneHashookPrice = double.Parse(MahsanehashookAccessor.GetPriceById(mahsanehashookId)) * product.Quantity;
                    mahsaneHashookPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = mahsaneHashookPrice, Quantity = product.Quantity });
                    //ShoperSal
                    var shopersalPrice = double.Parse(ShopersalAccessor.GetPriceById(shopersalId)) * product.Quantity;
                    shopersalPrices.Add(new Product { Id = product.Id, Name = product.Name, Manufacturer = product.Manufacturer, Price = shopersalPrice, Quantity = product.Quantity });
                }
                ++i;
            }

            var resultChains = new[]
            {
                new Chain
                {
                    Name = "רמי לוי",
                    Id = 1,
                    Max3Products = ramiLeviPrices.OrderByDescending(p => p.Price).Take(3),
                    Min3Products = ramiLeviPrices.OrderBy(p => p.Price).Take(3)
                },
                new Chain
                {
                    Name = "מחסני השוק",
                    Id = 2,
                    Max3Products = mahsaneHashookPrices.OrderByDescending(p => p.Price).Take(3),
                    Min3Products = mahsaneHashookPrices.OrderBy(p => p.Price).Take(3)
                },

                new Chain
                {
                    Name = "שופרסל",
                    Id = 3,
                    Max3Products = shopersalPrices.OrderByDescending(p => p.Price).Take(3),
                    Min3Products = shopersalPrices.OrderBy(p => p.Price).Take(3)
                }
            };
            var resultPrices = new[]
            {
                ramiLeviPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture),
                mahsaneHashookPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture),
                shopersalPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture)
            };
            return Tuple.Create(resultChains, resultPrices);
        }
    }
}