using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> SignInAsync(User data);

        Task UpdateUserAsync(int id, User userToUpdate);
    }
}