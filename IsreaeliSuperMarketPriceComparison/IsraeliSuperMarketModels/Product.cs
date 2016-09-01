using System;
using System.Runtime.Serialization;

namespace IsraeliSuperMarketModels
{
    [Serializable]
    public enum UnitQuantity
    {
        Kg,
        Item
    }

    [Serializable]
    [DataContract]
    public class Product : IProduct, IEquatable<Product>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"Name = {Name}, ID = {Id}";
        }
    }
}
