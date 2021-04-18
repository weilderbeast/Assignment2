using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using HttpApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AdultsController : ControllerBase
    {
        private readonly FileContext _fileContext = new FileContext();

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> Get()
        {
            var adults = _fileContext.Adults;
            return adults != null ? Ok(adults) : StatusCode(500, "something went wrong");
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> Post([FromBody] Adult adult)
        {
            try
            {
                _fileContext.Adults.Add(adult);
                Console.WriteLine("Written " + adult.LastName + " to file");
                _fileContext.SaveChanges();
                return Created($"/{adult.LastName}", adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}