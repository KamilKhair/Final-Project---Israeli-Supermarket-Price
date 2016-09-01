using System.Collections.Generic;
using System.Threading.Tasks;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketManager
{
    public interface ISuperMarketManager
    {
        Task<IProduct[]> GetProductsAsync();
        Task<IChain[]> GetChainsAsync();
        Task<IDictionary<Chain, double>> ComparePricesAsync(Product[] products);
    }
}