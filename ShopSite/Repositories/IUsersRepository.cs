using Entities;

namespace Repositories
{
    public interface IUsersRepository
    {
         Task<User> GetUserByIdAsync(int id);

        Task<User> CreateUserAsync(User user);

        Task<User> SignInAsync(User data);
        Task UpdateUserAsync(int id, User userToUpdate);

    }
}