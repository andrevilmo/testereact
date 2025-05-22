public interface IUserRepository
{
     Task<bool> Login(string email, string password);

     Task<bool> Register(User user);
}