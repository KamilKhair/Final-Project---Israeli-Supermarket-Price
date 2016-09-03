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
        Task<Tuple<Chain[], string[]>> ComparePricesAsync(Tuple<Product[], int[]> products);
        Task<Bitmap> GetImageAsync(int imageId);
    }
}