using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using HttpApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly FileContext _FileContext = new FileContext();

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> Get()
        {
            var families = _FileContext.Families;
            return families != null ? Ok(families) : StatusCode(500, "something went wrong");
        }

        [HttpPost]
        public async Task<ActionResult<Family>> Post([FromBody] Family family)
        {
            try
            {
                _FileContext.Families.Add(family);
                Console.WriteLine("Written family " + family.Adults[0].LastName + " to file");
                _FileContext.SaveChanges();
                return Created($"/{family.Adults[0].LastName}", family);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}