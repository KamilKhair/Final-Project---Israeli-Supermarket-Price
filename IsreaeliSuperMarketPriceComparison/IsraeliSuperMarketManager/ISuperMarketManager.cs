using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketManager
{
    public interface ISuperMarketManager
    {
        Task<IProduct[]> GetProductsAsync();
        Task<IChain[]> GetChainsAsync();
        Task<IDictionary<Chain, double>> ComparePricesAsync(IDictionary<Product, int> products);
        Task<Bitmap> GetImageAsync(int imageId);
    }
}