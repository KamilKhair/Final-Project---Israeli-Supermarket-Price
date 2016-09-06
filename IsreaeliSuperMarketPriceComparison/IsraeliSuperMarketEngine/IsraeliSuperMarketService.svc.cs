using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using IsraeliSuperMarketEngine.Accessors;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketEngine
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class IsraeliSuperMarketService
    {
        private MyDataAccessor _service;
        private MyDataAccessor Service => _service ?? (_service = new MyDataAccessor());

        [WebGet(UriTemplate = "/Products")]
        public Product[] GetProducts()
        {
            return Service.GetProducts();
        }

        [WebGet(UriTemplate = "/Product/{productId}")]
        public Product GetProduct(string productId)
        {
            return Service.GetProduct(productId);
        }

        [WebGet(UriTemplate = "/Chains")]
        public Chain[] GetChains()
        {
            return Service.GetChains();
        }

        [WebGet(UriTemplate = "/Image/{imageId}")]
        public string GetImage(string imageId)
        {
           return Service.GetImage(int.Parse(imageId));
        }

        [WebInvoke(UriTemplate = "/Compare")]
        public Tuple<Chain[], string[]> ComparePrices(Product[] products)
        {
            return Service.ComparePrices(products);
        }
    }
}
