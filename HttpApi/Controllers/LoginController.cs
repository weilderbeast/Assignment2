using System;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using HttpApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly FileContext _FileContext = new FileContext();
        
        [HttpPost]
        public async Task<ActionResult<bool>> Login([FromBody] User loggingUser)
        {
            var users = _FileContext.Users;
            var user = users.FirstOrDefault(user => user.Username.Equals(loggingUser.Username));
            
            if (user == null)
            {
                Console.WriteLine("user is null");
                return StatusCode(404, "User not found");
            }
            if (!user.Password.Equals(loggingUser.Password))
            {
                Console.WriteLine("password incorrect");
                return StatusCode(404, "Incorrect password");
            }

            Console.WriteLine("Returned "+ user.Username);
            return Ok(user);
        }
    }
}