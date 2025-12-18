using Blogging_Platform_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
           return await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        // returns number of times the username is registered in DB
        public async Task<int> GetUsernameRecordsAsync(User user)
        {
            return await _context.Users.Where(x => x.Name == user.Name).CountAsync();
        }

        // returns number of times the email is registered in DB
        public async Task<int> GetEmailRecordsAsync(User user)
        {
            return await _context.Users.Where(x => x.Email == user.Email).CountAsync();
        }
    }
}
