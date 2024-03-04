using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace KiddieBank.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KiddieBankContext _context;

        public UserRepository(KiddieBankContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
      
    }
}

