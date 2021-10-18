namespace BookStore.Services
{
    public interface IUserService
    {
        string GetUserID();
        bool IsAuthenticated();
    }
}