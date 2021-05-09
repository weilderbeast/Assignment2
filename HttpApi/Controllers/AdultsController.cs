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
    [Route("/api/[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultsRepo _adultsRepo;
        private readonly FileContext _FileContext = new FileContext();

        public AdultsController(IAdultsRepo adultsRepo)
        {
            _adultsRepo = adultsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> Get()
        {
            try
            {
                var adults = _FileContext.Adults;
                foreach (var adult in adults)
                {
                    Console.WriteLine("writing " + adult.FirstName + " to db");
                    try
                    {
                        await _adultsRepo.AddAsync(adult);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return StatusCode(500, "error");
            // var adults = await _adultsRepo.GetAllAsync();
            // return adults != null ? Ok(adults) : StatusCode(500, "something went wrong");
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> Post([FromBody] Adult adult)
        {
            try
            {
                await _adultsRepo.AddAsync(adult);
                Console.WriteLine("Written " + adult.LastName + " to db");
                return Created($"/{adult.LastName}", adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task DeleteAsync([FromRoute] int id)
        {
            try
            {
                await _adultsRepo.RemoveAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpPatch]
        public async Task EditAsync([FromBody] Adult adult)
        {
            try
            {
                await _adultsRepo.RemoveAsync(adult.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}