using System;
using System.Runtime.Serialization;

namespace IsraeliSuperMarketModels
{
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
        public double Price { get; set; }
        [DataMember]
        public double Quantity { get; set; }
        [DataMember]
        public bool IsWeighted { get; set; }
        [DataMember]
        public string Category { get; set; }

        public bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"ID = {Id}, Name = {Name}, Manufacturer = {Manufacturer}";
        }
    }
}
