using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using IsraeliSuperMarketEngine.Data;
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

        private readonly DataAccess _service = new DataAccess();
        [WebGet(UriTemplate = "/Products")]
        public Product[] GetProducts()
        {
            return _service.GetProducts();
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
        public Dictionary<Chain, double> ComparePrices(IDictionary<Product, int> products)
        {
            return _service.ComparePrices(products);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
