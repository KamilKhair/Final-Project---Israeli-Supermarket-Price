using System.Collections;
using System.Collections.Generic;

namespace IsraeliSuperMarketModels
{
    public interface IChain
    {
        int Id { get; }
        string Name { get; }
        IEnumerable<string> Max3Products { get; }
        IEnumerable<string> Min3Products { get; }
    }
}