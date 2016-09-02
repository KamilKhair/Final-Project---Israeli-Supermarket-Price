using System.Collections;
using System.Collections.Generic;

namespace IsraeliSuperMarketModels
{
    public interface IChain
    {
        int Id { get; }
        string Name { get; }
        IList<IProduct> Max3Products { get; }
        IList<IProduct> Min3Products { get; }
    }
}