using System;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using HttpApi.Resources;
using HttpApi.Resources.persistence.repos;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IUsersRepo _repo;
        
        public LoginController(IUsersRepo repo)
        {
            _repo = repo;
        }
        
        [HttpPost]
        public async Task<ActionResult<bool>> Login([FromBody] User loggingUser)
        {
            try
            {
                var response = await _repo.ValidateAsync(loggingUser.Username, loggingUser.Password);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
            
        }
    }
}