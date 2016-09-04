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
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public IEnumerable<Product> Max3Products { get; set; }
        [DataMember]
        public IEnumerable<Product> Min3Products { get; set; }

        public bool Equals(Chain other)
        {
            return Id == other.Id;
        }
        public override string ToString()
        {
            return $"ID = {Id}, Name = {Name}";
        }
    }
}
