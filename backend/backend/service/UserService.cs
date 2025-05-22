using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.service
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;

        public UserService(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }
        public async Task<bool> Login(string email, string password)
        {
            return await _userRespository.Login(email,password);
        }
        
        public async Task<bool> Register(User user) {
            return await _userRespository.Register(user);        
        }
    }
}