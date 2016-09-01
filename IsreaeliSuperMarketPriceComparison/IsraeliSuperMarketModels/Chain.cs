using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IsraeliSuperMarketModels
{
    [Serializable]
    [DataContract]
    public class Chain : IChain, IEquatable<Chain>
    {
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Chain other)
        {
            return Id == other.Id;
        }
        public override string ToString()
        {
            return $"Id = {Id}";
        }
    }
}
