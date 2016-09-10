using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketManager
{
    public interface ISuperMarketManager
    {
        Task<IEnumerable<IProduct>> GetProductsAsync();
        Task<IProduct> GetProductAsync(int productId);
        Task<Tuple<IEnumerable<Chain>, IEnumerable<string>>> ComparePricesAsync(IEnumerable<Product> products);
        Task<Bitmap> GetImageAsync(int imageId);
        Task<Tuple<User, bool, string>> LogInAsync(IUser user);
    }
}