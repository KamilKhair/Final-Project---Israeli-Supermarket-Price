using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
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

        private MahsaneHashookAccessor MahsanehashookAccessor
            => _mahsanehashookAccessor ?? (_mahsanehashookAccessor = new MahsaneHashookAccessor());

        private ShopersalAccessor _shopersalAccessor;

        private ShopersalAccessor ShopersalAccessor
            => _shopersalAccessor ?? (_shopersalAccessor = new ShopersalAccessor());

        public IEnumerable<Product> GetProducts()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:/ISMC/Data/Products.xml");
            if (xmlDocument.DocumentElement == null)
            {
                return null;
            }
            var products = 
                (
                from XmlNode node in xmlDocument.DocumentElement.ChildNodes
                where node.Attributes != null
                select new Product
                {
                    Id = int.Parse(node.Attributes["Id"].InnerText),
                    Name = node.Attributes["Name"].InnerText,
                    Manufacturer = node.Attributes["Manufacturer"].InnerText,
                    IsWeighted = node.Attributes["IsWeighted"].InnerText == "true"
                }).ToList();
            return products;
        }

        public Product GetProduct(string productId)
        {
            var products = XElement.Load(@"D:/ISMC/Data/Products.xml");
            var product = products.Elements("Product").Single(element => element.Attribute("Id")?.Value == productId);
            return new Product
            {
                Id = int.Parse(productId),
                Name = product.Attribute("Name")?.Value,
                Manufacturer = product.Attribute("Manufacturer")?.Value,
            };
        }

        public string GetImage(int imageId)
        {
            try
            {
                using (var image = (Bitmap) Image.FromFile(@"D:\ISMC\pictures\" + imageId + ".bmp", true))
                {
                    return image.ToBase64String(ImageFormat.Bmp);
                }
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(@"Image D:\ISMC\pictures\" + imageId + ".bmp Not Found", ex);
            }
        }

        public Tuple<IEnumerable<Chain>, IEnumerable<string>> ComparePrices(IEnumerable<Product> products)
        {
            var catalog = XElement.Load(@"D:/ISMC/Data/Products.xml");
            var ramiLeviPrices = new List<Product>();
            var mahsaneHashookPrices = new List<Product>();
            var shopersalPrices = new List<Product>();
            foreach (var product in products.AsParallel())
            {
                var productElement =
                    catalog.Elements("Product").Single(el => el.Attribute("Id")?.Value == product.Id.ToString());
                var isComparable = productElement.Attribute("IsComparable")?.Value == "true";
                if (isComparable)
                {
                    var comparableSearchId = productElement.Attribute("SearchId")?.Value;

                    var ramiLeviPrice = double.Parse(RamiLeviAccessor.GetPriceById(comparableSearchId))* product.Quantity;
                    ramiLeviPrices.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = ramiLeviPrice,
                        Quantity = product.Quantity
                    });

                    var mahsaneHashookPrice = double.Parse(MahsanehashookAccessor.GetPriceById(comparableSearchId)) * product.Quantity;
                    mahsaneHashookPrices.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = mahsaneHashookPrice,
                        Quantity = product.Quantity
                    });

                    var shopersalPrice = double.Parse(ShopersalAccessor.GetPriceById(comparableSearchId)) * product.Quantity;
                    shopersalPrices.Add(new Product
                    { Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = shopersalPrice,
                        Quantity = product.Quantity });
                }
                else
                {
                    var chains = productElement.Elements("Chain").ToList();
                    var ramiLeviId = chains.Single(el => el.Attribute("Name")?.Value == "RamiLevi").Attribute("SearchId")?.Value;
                    var mahsanehashookId = chains.Single(el => el.Attribute("Name")?.Value == "MahsaneHashook").Attribute("SearchId")?.Value;
                    var shopersalId = chains.Single(el => el.Attribute("Name")?.Value == "Shopersal").Attribute("SearchId")?.Value;

                    var ramiLeviPrice = double.Parse(RamiLeviAccessor.GetPriceById(ramiLeviId)) * product.Quantity;
                    ramiLeviPrices.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = ramiLeviPrice,
                        Quantity = product.Quantity
                    });

                    var mahsaneHashookPrice = double.Parse(MahsanehashookAccessor.GetPriceById(mahsanehashookId)) * product.Quantity;
                    mahsaneHashookPrices.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = mahsaneHashookPrice,
                        Quantity = product.Quantity
                    });

                    var shopersalPrice = double.Parse(ShopersalAccessor.GetPriceById(shopersalId)) * product.Quantity;
                    shopersalPrices.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Price = shopersalPrice,
                        Quantity = product.Quantity
                    });
                }
            }

            var resultChains = new List<Chain>()
            {
                new Chain
                {
                    Name = "רמי לוי",
                    Id = 1,
                    Products = ramiLeviPrices
                },
                new Chain
                {
                    Name = "מחסני השוק",
                    Id = 2,
                    Products = mahsaneHashookPrices
                },

                new Chain
                {
                    Name = "שופרסל",
                    Id = 3,
                    Products = shopersalPrices
                }
            };
            var resultPrices = new List<string>()
            {
                ramiLeviPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture),
                mahsaneHashookPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture),
                shopersalPrices.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture)
            };
            return Tuple.Create(resultChains.AsEnumerable(), resultPrices.AsEnumerable());
        }

        public Tuple<User, bool, string> LogIn(User user)
        {
            var users = XElement.Load(@"D:/ISMC/Data/Users.xml");
            var usersList = users.Elements("User").Select(us => new User
            {
                FirstName = us.Attribute("FirstName")?.Value,
                LastName = us.Attribute("LastName")?.Value,
                UserName = us.Attribute("UserName")?.Value,
                Password = us.Attribute("Password")?.Value
            }).ToList();
            if (!usersList.Contains(user))
            {
                return Tuple.Create(new User(), false, "שם משתמש לא קיים");
            }
            var storedUser = usersList.Single(us => us.UserName.Equals(user.UserName));
            if (!storedUser.Password.Equals(user.Password))
            {
                return Tuple.Create(new User(), false, "סיסמה שגויה");
            }
            var resultUser = new User
            {
                FirstName = storedUser.FirstName,
                LastName = storedUser.LastName,
                UserName = storedUser.UserName,
                Password = string.Empty
            };
            return Tuple.Create(resultUser, true, "התחברת בהצלחה");
        }
    }
}