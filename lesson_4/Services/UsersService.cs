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

       
        

        public async Task<User1> CreateUserAsync(User1 user)
        {

            return await _usersRepository.CreateUserAsync(user);


        }

        public async Task<User1> GetUserByIdAsync(int id)
        {

            return await _usersRepository.GetUserByIdAsync(id);
        }

        public async Task<User1> SignInAsync(User1 data)
        {
            return await _usersRepository.SignInAsync(data);

        }

        public async Task UpdateUserAsync(int id, User1 userToUpdate)
        {

            await _usersRepository.UpdateUserAsync(id, userToUpdate);
        }
    }
}