using Advanced.NET_Labb3.Models;
using Advanced.NET_Labb3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced.NET_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _context;
        public PersonController(IPersonRepository context)
        {
            _context = context;
        }


        [HttpGet("Persons")]
        public async Task<ActionResult<Person>> GetAll()
        {
            try
            {
                return Ok(await _context.GettAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to person from Database...");
            }
        }

        [HttpGet("GetPersonInterest{id:int}")]
        public async Task<ActionResult<Person>> GetIntrestPersonID(int id)
        {
            try
            {
                var result = await _context.GetPInterest(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database...");
            }
        }


        [HttpGet("GetPersonLinks{Id:int}")]
        public async Task<ActionResult<Person>> GetLinkPersonID(int Id)
        {
            try
            {
                var result = await _context.GetPLinks(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database...");
            }
        }

        [HttpPost("AddInterest")]
        public async Task<IActionResult> AddInterestToPerson(int personID, int interest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _context.AddIPerson(personID, interest);
                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to post interest to Database...");
            }
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLinkToPerson(int personID, int interestID, string url)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _context.AddLPerson(personID, interestID, url);
                return Ok();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to post data to Database...");
            }
        }

    }
}
