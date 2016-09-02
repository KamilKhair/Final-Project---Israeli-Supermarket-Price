using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using IsraeliSuperMarketEngine.Accessors;
using IsraeliSuperMarketEngine.Extensions;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketEngine.Data
{
    public class DataAccess
    {
        private RamiLeviAccessor _ramiLeviAccessor;
        private RamiLeviAccessor RamiLeviAccessor => _ramiLeviAccessor ?? (_ramiLeviAccessor = new RamiLeviAccessor());
        private HatsiHinamAccessor _hatsiHinamAccessor;
        private HatsiHinamAccessor HatsiHinamAccessor => _hatsiHinamAccessor ?? (_hatsiHinamAccessor = new HatsiHinamAccessor());
        private KeshetTaamimAccessor _keshetTaamimAccessor;
        private KeshetTaamimAccessor KeshetTaamimAccessor => _keshetTaamimAccessor ?? (_keshetTaamimAccessor = new KeshetTaamimAccessor());
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

        public Dictionary<Chain, double> ComparePrices(IDictionary<Product, int> products)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:/Products.xml");
            if (xmlDocument.DocumentElement == null)
            {
                return null;
            }
        }
    }
}