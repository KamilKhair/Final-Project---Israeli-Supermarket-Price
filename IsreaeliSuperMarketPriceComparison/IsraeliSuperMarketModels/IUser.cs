namespace IsraeliSuperMarketModels
{
    public interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
        string UserName { get; }
        string Password { get; }
    }
}
