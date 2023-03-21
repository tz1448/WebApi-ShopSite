using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task<User1> CreateUserAsync(User1 user);
        Task<User1> GetUserByIdAsync(int id);
        Task<User1> SignInAsync(User1 data);

        Task UpdateUserAsync(int id, User1 userToUpdate);
    }
}