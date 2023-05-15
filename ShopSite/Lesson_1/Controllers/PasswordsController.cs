using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class PasswordsController : ControllerBase
{

        IPasswordsServices _passwordsService;
    
        public PasswordsController(IPasswordsServices passwordsService)
        {
            _passwordsService = passwordsService;

        }
        // POST api/<PasswordsController>
        [HttpPost]
        public int Post([FromBody] Password password)
        {
            return _passwordsService.getPasswordRate(password);
        }



    }
}
