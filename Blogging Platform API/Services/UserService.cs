using Blogging_Platform_API.Data.Repositories;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            int usernameRecords = await _userRepository.GetUsernameRecordsAsync(user);
            int emailRecords = await _userRepository.GetEmailRecordsAsync(user);

            if (usernameRecords  > 0)
            {
                throw new ArgumentException("This username already exists");
            }

            if (emailRecords > 0)
            {
                throw new ArgumentException("This email address already exists");
            }

            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(int id,User user)
        {
            if (id != user.Id)
            {
                throw new ArgumentException("The user id's must match");
            }

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
