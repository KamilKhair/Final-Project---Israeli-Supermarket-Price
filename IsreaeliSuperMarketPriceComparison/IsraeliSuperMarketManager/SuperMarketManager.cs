using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using IsraeliSuperMarketManager.Extensions;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketManager
{
    public class SuperMarketManager : ISuperMarketManager
    {
        public Task<IEnumerable<IProduct>> GetProductsAsync()
        {
            IEnumerable<IProduct> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Products");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "GET";
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<Product>));
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    responseObject = serializer.ReadObject(responseStream) as IEnumerable<IProduct>;
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<IProduct> GetProductAsync(int productId)
        {
            IProduct responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var url = "http://localhost:20997/IsraeliSuperMarketService.svc/Product/" + productId;
                var client = new WebClient();
                client.Headers.Add("Accept", "application/json");
                var result = client.DownloadString(url);
                var serializer = new DataContractJsonSerializer(typeof(Product));
                using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
                {
                    responseObject = serializer.ReadObject(stream) as Product;
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<IEnumerable<IChain>> GetChainsAsync()
        {
            IEnumerable<IChain> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Chains");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "GET";
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<IChain>));
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    responseObject = serializer.ReadObject(responseStream) as IEnumerable<IChain>;
                }
            }).ContinueWith(x => responseObject);
        }

        public Task<Tuple<IEnumerable<Chain>, IEnumerable<string>>> ComparePricesAsync(IEnumerable<Product> products)
        {
            Tuple<IEnumerable<Chain>, IEnumerable<string>> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/Compare");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<Product>));
                var requestStream = request.GetRequestStream();
                serializer.WriteObject(requestStream, products);
                requestStream.Close();
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var serializer2 = new DataContractJsonSerializer(typeof(Tuple<IEnumerable<Chain>, IEnumerable<string>>));
                if (responseStream != null)
                {
                    responseObject = serializer2.ReadObject(responseStream) as Tuple<IEnumerable<Chain>, IEnumerable<string>>;
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

        public Task<Tuple<User, bool, string>> LogInAsync(IUser user)
        {
            Tuple<User, bool, string> responseObject = null;
            return Task.Factory.StartNew(() =>
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:20997/IsraeliSuperMarketService.svc/LogIn");
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                var serializer = new DataContractJsonSerializer(typeof(User));
                var requestStream = request.GetRequestStream();
                serializer.WriteObject(requestStream, (User) user);
                requestStream.Close();
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var serializer2 = new DataContractJsonSerializer(typeof(Tuple<User, bool, string>));
                if (responseStream != null)
                {
                    responseObject = serializer2.ReadObject(responseStream) as Tuple<User, bool, string>;
                }
            }).ContinueWith(x => responseObject);
        }
    }
}
