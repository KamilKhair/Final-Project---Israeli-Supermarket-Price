using System;
using System.Collections.Generic;
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
        private MyDataAccessor _dataAccess;
        private MyDataAccessor DataAccess => _dataAccess ?? (_dataAccess = new MyDataAccessor());

        [WebGet(UriTemplate = "/Products")]
        public IEnumerable<Product> GetProducts()
        {
            return DataAccess.GetProducts();
        }

        [WebGet(UriTemplate = "/Product/{productId}")]
        public IProduct GetProduct(string productId)
        {
            return DataAccess.GetProduct(productId);
        }

        [WebGet(UriTemplate = "/Image/{imageId}")]
        public string GetImage(string imageId)
        {
           return DataAccess.GetImage(int.Parse(imageId));
        }

        [WebInvoke(UriTemplate = "/Compare")]
        public Tuple<IEnumerable<Chain>, IEnumerable<string>> ComparePrices(IEnumerable<Product> products)
        {
            return DataAccess.ComparePrices(products);
        }

        [WebInvoke(UriTemplate = "/LogIn")]
        public Tuple<User, bool, string> LoagIn(User user)
        {
            return DataAccess.LogIn(user);
        }
    }
}
