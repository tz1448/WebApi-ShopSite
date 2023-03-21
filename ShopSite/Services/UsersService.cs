using Entities;
using Repositories;

namespace Services
{
    public class UsersService: IUsersService
    {
        static private string path = "./Db.txt";

        private IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

       
        

        public async Task<User> CreateUserAsync(User user)
        {

            return await _usersRepository.CreateUserAsync(user);


        }

        public async Task<User> GetUserByIdAsync(int id)
        {

            return await _usersRepository.GetUserByIdAsync(id);
        }

        public async Task<User> SignInAsync(User data)
        {
            return await _usersRepository.SignInAsync(data);

        }

        public async Task UpdateUserAsync(int id, User userToUpdate)
        {

            await _usersRepository.UpdateUserAsync(id, userToUpdate);
        }
    }
}