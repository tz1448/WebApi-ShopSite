
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
        ILogger<UsersController> _logger;
        public UsersController(IUsersService usersService, IPasswordsServices passwordsService,IMapper mapper, ILogger<UsersController> logger)

        {
            _usersService = usersService;
            _passwordsService=passwordsService;
            _mapper = mapper;
            _logger = logger;
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
      
       public async Task<ActionResult<UserDto>> SignIn([FromBody] UserLoginDto dataDto)
        {
            _logger.LogInformation($"Login attempted with  email {dataDto.Email} and password{dataDto.Password}");
            User data = _mapper.Map<UserLoginDto, User>(dataDto);
            User user =await _usersService.SignInAsync(data);
            UserDto userDto = _mapper.Map<User, UserDto>(user);
           
            return userDto == null ? NotFound() : Ok(userDto);


        }
      
    }
}
