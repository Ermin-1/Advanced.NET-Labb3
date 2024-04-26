using Advanced.NET_Labb3.Models;
using Advanced.NET_Labb3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Advanced.NET_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonRepository _personRepository;
        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _personRepository.GettAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrivve persons from database!");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person newPerson)
        {

            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                await _personRepository.AddPerson(newPerson);
                return CreatedAtAction(nameof(GetAll), new { id = newPerson.PersonId }, newPerson);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create new person in database!");
            }
           
        }
    }
}
