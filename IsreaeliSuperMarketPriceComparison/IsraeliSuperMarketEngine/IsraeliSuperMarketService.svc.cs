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
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        private readonly MyDataAccessor _service = new MyDataAccessor();

        [WebGet(UriTemplate = "/Products")]
        public Product[] GetProducts()
        {
            return _service.GetProducts();
        }

        [WebGet(UriTemplate = "/Product/{productId}")]
        public Product GetProduct(string productId)
        {
            return _service.GetProduct(productId);
        }

        [WebGet(UriTemplate = "/Chains")]
        public Chain[] GetChains()
        {
            return _service.GetChains();
        }

        [WebGet(UriTemplate = "/Image/{imageId}")]
        public string GetImage(string imageId)
        {
           return _service.GetImage(int.Parse(imageId));
        }

        [WebInvoke(UriTemplate = "/Compare")]
        public Tuple<Chain[], string[]> ComparePrices(Product[] products)
        {
            return _service.ComparePrices(products);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
