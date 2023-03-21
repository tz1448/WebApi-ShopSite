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
    // GET: api/<PasswordsController>
    [HttpGet]
        
        public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<PasswordsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PasswordsController>
    [HttpPost]
    public int Post([FromBody] Password password)
    {
            return _passwordsService.getPasswordRate(password);
    }

    // PUT api/<PasswordsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PasswordsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
