using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketManager
{
    public class SuperMarketManager : ISuperMarketManager
    {
        public Task<IProduct[]> GetProductsAsync()
        {
            IProduct[] responseObject = { };
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Products");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "GET";
                var serializer = new DataContractJsonSerializer(typeof(Product[]));
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    responseObject = serializer.ReadObject(responseStream) as IProduct[];
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<IChain[]> GetChainsAsync()
        {
            IChain[] responseObject = { };
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Chains");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "GET";
                var serializer = new DataContractJsonSerializer(typeof(Chain[]));
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    responseObject = serializer.ReadObject(responseStream) as IChain[];
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<IDictionary<Chain, double>> ComparePricesAsync(Product[] products)
        {
            IDictionary<Chain, double> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Compare");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                var serializer = new DataContractJsonSerializer(typeof(Product[]));
                var requestStream = request.GetRequestStream();
                serializer.WriteObject(requestStream, products);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var serializer2 = new DataContractJsonSerializer(typeof(IDictionary<Chain, double>));
                if (responseStream != null)
                {
                    responseObject = serializer2.ReadObject(responseStream) as IDictionary<Chain, double>;
                }
            }).ContinueWith(x => responseObject);
        }
    }
}
