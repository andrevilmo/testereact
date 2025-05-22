public interface IUserService
{
    Task<bool> Login(string email, string password);
    Task<bool> Register(User user);
}