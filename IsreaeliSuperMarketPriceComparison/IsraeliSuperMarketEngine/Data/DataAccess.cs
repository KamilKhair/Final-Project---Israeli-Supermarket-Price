using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using IsraeliSuperMarketEngine.Accessors;
using IsraeliSuperMarketEngine.Extensions;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketEngine.Data
{
    public class DataAccess
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
                        Manufacturer = node.Attributes["Manufacturer"].InnerText
                    };
                }
            }
            return products;
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

        public Tuple<Chain[], string[]> ComparePrices(Tuple<Product[], int[]> products)
        {
            var catalog = XElement.Load(@"D:/Products.xml");
            var ramiLeviPrices = new List<string>();
            var mahsaneHashookPrices = new List<string>();
            var shopersalPrices = new List<string>();
            var i = 0;
            foreach (var product in products.Item1.AsParallel())
            {
                var productElement =
                    catalog.Elements("Product").Single(el => el.Attribute("Id").Value == product.Id.ToString());
                var isComparable = productElement.Attribute("IsComparable").Value == "true";
                if (isComparable)
                {
                    var comparableSearchId = productElement.Attribute("SearchId").Value;
                    
                    //RamiLevi
                    ramiLeviPrices.Add((double.Parse(RamiLeviAccessor.GetPriceById(comparableSearchId))*products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                    //MahsaneHashook
                    mahsaneHashookPrices.Add((double.Parse(MahsanehashookAccessor.GetPriceById(comparableSearchId))* products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                    //ShoperSal
                    shopersalPrices.Add((double.Parse(ShopersalAccessor.GetPriceById(comparableSearchId))* products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    var chains = productElement.Elements("Chain").ToList();
                    var ramiLeviId = chains.Single(el => el.Attribute("Name").Value == "RamiLevi").Attribute("SearchId").Value;
                    var mahsanehashookId = chains.Single(el => el.Attribute("Name").Value == "MahsaneHashook").Attribute("SearchId").Value;
                    var shopersalId = chains.Single(el => el.Attribute("Name").Value == "Shopersal").Attribute("SearchId").Value;

                    //RamiLevi
                    ramiLeviPrices.Add((double.Parse(RamiLeviAccessor.GetPriceById(ramiLeviId))* products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                    //MahsaneHashook
                    mahsaneHashookPrices.Add((double.Parse(MahsanehashookAccessor.GetPriceById(mahsanehashookId))* products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                    //ShoperSal
                    shopersalPrices.Add((double.Parse(ShopersalAccessor.GetPriceById(shopersalId))* products.Item2[i]).ToString(CultureInfo.InvariantCulture));
                }
                ++i;
            }

            var resultChains = new[]
            {
                new Chain
                {
                    Name = "RamiLevi",
                    Id = 1,
                    Max3Products = ramiLeviPrices.OrderByDescending(x => x).Take(3),
                    Min3Products = ramiLeviPrices.OrderBy(x => x).Take(3)
                },
                new Chain
                {
                    Name = "MahsaneHashook",
                    Id = 1,
                    Max3Products = mahsaneHashookPrices.OrderByDescending(x => x).Take(3),
                    Min3Products = mahsaneHashookPrices.OrderBy(x => x).Take(3)
                },

                new Chain
                {
                    Name = "Shopersal",
                    Id = 1,
                    Max3Products = shopersalPrices.OrderByDescending(x => x).Take(3),
                    Min3Products = shopersalPrices.OrderBy(x => x).Take(3)
                }
            };
            var resultPrices = new[]
            {
                ramiLeviPrices.Sum(x => double.Parse(x)).ToString(CultureInfo.InvariantCulture),
                mahsaneHashookPrices.Sum(x => double.Parse(x)).ToString(CultureInfo.InvariantCulture),
                shopersalPrices.Sum(x => double.Parse(x)).ToString(CultureInfo.InvariantCulture)
            };
            return Tuple.Create(resultChains, resultPrices);
        }
    }
}