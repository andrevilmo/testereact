using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using backend.EF;

namespace backend.repository
{
    public class UserRepository : IUserRepository
    {
         private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(string email, string password)
        {
            var consulta =  from e in _context.Set<User>()
            where e.email == email && e.password == password
            select 1;

            return   consulta.Any();
        }

        Task<bool> IUserRepository.Register(User user)
        { 
            try {
                _context.Users.Add(user);
                _context.SaveChanges();
            }catch(Exception exp) {
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace.ToString());
                return  Task.FromResult(false);
            }
            return  Task.FromResult(true);
        }
    }
}