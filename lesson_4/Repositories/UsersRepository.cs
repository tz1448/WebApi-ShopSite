using Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository: IUsersRepository
    {

        static private string path = "M:\\API\\lesson_4\\Entities\\Db.txt";

        StoryDbContext _storyDbContext;
        public UsersRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }
   
        public async Task<User1>  GetUserByIdAsync(int id)
        {

            User1 user= await _storyDbContext.Users.FindAsync(id);
           // await _storyDbContext.SaveChangesAsync();
            return user;

        }
            public async Task<User1> CreateUserAsync( User1 user)
            {

             await _storyDbContext.Users.AddAsync(user);
            await _storyDbContext.SaveChangesAsync();
            return user;

            }
           
            public async Task<User1>  SignInAsync(User1 data)
            {

            List<User1> user = await _storyDbContext.Users.Where(u => u.Email == data.Email && u.Password == data.Password).ToListAsync();
            // await _storyDbContext.SaveChangesAsync();

            if (user.Count() == 0)
                return null;
            return user[0];
            }
     
            public async Task UpdateUserAsync(int id, User1 userToUpdate)
            {

            _storyDbContext.Users.Update(userToUpdate); 

            await _storyDbContext.SaveChangesAsync();
            

            }

          

        }
}