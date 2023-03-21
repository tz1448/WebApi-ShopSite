
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUsersService _usersService;
        IPasswordsServices _passwordsService;
        public UsersController(IUsersService usersService, IPasswordsServices passwordsService)
        {
            _usersService = usersService;
            _passwordsService=passwordsService;
    }
        
        // GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return usersService.GetUserById(id);
        //}

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user =await  _usersService.GetUserByIdAsync(id);
            return user == null ? NotFound() :user;
                   
        }
      

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            Password pass = new Password(user.Password);
            if(_passwordsService.getPasswordRate(pass)>2)
            {
                User userCreated =await _usersService.CreateUserAsync(user);
                if (userCreated != null)
                    return CreatedAtAction(nameof(Get), new { id = userCreated.Id }, userCreated);
            }

            return BadRequest("email already exists"); ;


        }
        //POST api/<LoginController>
        [HttpPost]
        [Route("signIn")]
       // public ActionResult<User> Post1([FromBody] string password,string email)
       public async Task<ActionResult<User>> SignIn([FromBody] User data)
        {
            User user =await _usersService.SignInAsync(data);
            return user == null ? NotFound() : user;


        }
      //  PUT api/<LoginController>
       
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
           await _usersService.UpdateUserAsync(id, userToUpdate);
           


        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //return nameof(GetUserById, user.UserId, user)
        }
    }
}
