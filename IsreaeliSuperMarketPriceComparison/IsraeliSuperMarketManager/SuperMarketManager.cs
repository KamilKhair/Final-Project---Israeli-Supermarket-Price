using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using IsraeliSuperMarketEngine.Extensions;
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

        public Task<Tuple<Chain[], string[]>> ComparePricesAsync(Tuple<Product[], int[]> products)
        {
            Tuple<Chain[], string[]> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Compare");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                var serializer = new DataContractJsonSerializer(typeof(Tuple<Product[], int[]>));
                var requestStream = request.GetRequestStream();
                serializer.WriteObject(requestStream, products);
                requestStream.Close();
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var serializer2 = new DataContractJsonSerializer(typeof(Tuple<Chain[], string[]>));
                if (responseStream != null)
                {
                    responseObject = serializer2.ReadObject(responseStream) as Tuple<Chain[], string[]>;
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<Bitmap> GetImageAsync(int imageId)
        {
            string responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var url = "http://localhost:20997/IsraeliSuperMarketService.svc/Image/" + imageId;
                var client = new WebClient();
                client.Headers.Add("Accept", "application/json");
                var result = client.DownloadString(url);
                var serializer = new DataContractJsonSerializer(typeof(string));
                using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
                {
                    responseObject = serializer.ReadObject(stream) as string;
                }
            }).ContinueWith(x => responseObject.Base64StringToBitmap());
        }
    }
}
