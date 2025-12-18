using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
