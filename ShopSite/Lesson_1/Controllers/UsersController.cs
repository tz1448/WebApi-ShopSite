
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUsersService _usersService;
        IPasswordsServices _passwordsService;
        IMapper _mapper;

        public UsersController(IUsersService usersService, IPasswordsServices passwordsService,IMapper mapper)

        {
            _usersService = usersService;
            _passwordsService=passwordsService;
            _mapper = mapper;
        }
        
       

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User user =await  _usersService.GetUserByIdAsync(id);
            UserDto userDto = _mapper.Map<User, UserDto>(user);
            return user == null ? NotFound() :userDto;
                   
        }
      

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] User newUser)
        {
            Password pass = new Password(newUser.Password);
            if(_passwordsService.getPasswordRate(pass)>2)
            {
                User userCreated =await _usersService.CreateUserAsync(newUser);
                UserDto userDto = _mapper.Map<User, UserDto>(userCreated);
                if (userCreated != null)
                    return CreatedAtAction(nameof(Get), new { id = userCreated.Id }, userDto);
            }

            return BadRequest();


        }
        //POST api/<LoginController>
        [HttpPost]
        [Route("signIn")]
       // public ActionResult<User> Post1([FromBody] string password,string email)
       public async Task<ActionResult<UserDto>> SignIn([FromBody] UserLoginDto dataDto)
        {
            User data = _mapper.Map<UserLoginDto, User>(dataDto);
            User user =await _usersService.SignInAsync(data);
            UserDto userDto = _mapper.Map<User, UserDto>(user);
            return userDto == null ? NotFound() : Ok(userDto);


        }
      
    }
}
