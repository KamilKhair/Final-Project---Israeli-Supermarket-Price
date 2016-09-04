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
        Task<IProduct> GetProductAsync(int productId);
        Task<IChain[]> GetChainsAsync();
        Task<Tuple<Chain[], string[]>> ComparePricesAsync(Product[] products);
        Task<Bitmap> GetImageAsync(int imageId);
    }
}