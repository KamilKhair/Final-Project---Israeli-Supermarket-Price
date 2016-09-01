using System.Collections.Generic;
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
        public Product[] GetChains()
        {
            return _service.GetProducts();
        }

        [WebInvoke(UriTemplate = "/Compare")]
        public Dictionary<Chain, double> ComparePrices(Product[] products)
        {
            return null;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
