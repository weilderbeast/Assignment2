using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using HttpApi.Resources;
using HttpApi.Resources.persistence.repos;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly FileContext _FileContext = new FileContext();
        private IFamilyRepo _familyRepo;

        public FamilyController(IFamilyRepo familyRepo)
        {
            _familyRepo = familyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> Get()
        {
            try
            {
                var families = _FileContext.Families;
                foreach (var family in families)
                {
                    Console.WriteLine("adding " + family.StreetName + " to db");
                    await _familyRepo.AddAsync(family);
                }
            
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            
            return StatusCode(500, "error");
            
            
            // var families = await _familyRepo.GetAllAsync();
            // return families != null ? Ok(families) : StatusCode(500, "something went wrong");
        }

        [HttpPost]
        public async Task<ActionResult<Family>> Post([FromBody] Family family)
        {
            try
            {
                await _familyRepo.AddAsync(family);
                Console.WriteLine("Written family " + family.Adults[0].LastName + " to file");
                return Created($"/{family.Adults[0].LastName}", family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}