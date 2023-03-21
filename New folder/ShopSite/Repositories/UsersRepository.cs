using Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository: IUsersRepository
    {

       

        StoryDbContext _storyDbContext;
        public UsersRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }
   
        public async Task<User>  GetUserByIdAsync(int id)
        {

            User user= await _storyDbContext.Users.FindAsync(id);
           // await _storyDbContext.SaveChangesAsync();
            return user;

        }
            public async Task<User> CreateUserAsync( User user)
            {

             await _storyDbContext.Users.AddAsync(user);
            await _storyDbContext.SaveChangesAsync();
            return user;

            }
           
            public async Task<User>  SignInAsync(User data)
            {

            List<User> user = await _storyDbContext.Users.Where(u => u.Email == data.Email && u.Password == data.Password).ToListAsync();
            // await _storyDbContext.SaveChangesAsync();

            if (user.Count() == 0)
                return null;
            return user[0];
            }
     
            public async Task UpdateUserAsync(int id, User userToUpdate)
            {

            _storyDbContext.Users.Update(userToUpdate); 

            await _storyDbContext.SaveChangesAsync();
            

            }

          

        }
}