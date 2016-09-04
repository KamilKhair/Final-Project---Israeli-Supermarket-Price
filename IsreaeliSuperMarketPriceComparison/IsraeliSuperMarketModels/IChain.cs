using System.Collections;
using System.Collections.Generic;

namespace IsraeliSuperMarketModels
{
    public interface IChain
    {
        int Id { get; }
        string Name { get; }
        IEnumerable<Product> Max3Products { get; }
        IEnumerable<Product> Min3Products { get; }
    }
}