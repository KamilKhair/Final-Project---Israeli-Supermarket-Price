namespace IsraeliSuperMarketModels
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        string Manufacturer { get; }
        string ToString();
    }
}
