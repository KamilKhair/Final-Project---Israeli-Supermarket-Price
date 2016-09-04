namespace IsraeliSuperMarketModels
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        string Manufacturer { get; }
        double Quantity { get; }
        double Price { get; }
        bool IsWeighted { get; }
        string ToString();
    }
}
