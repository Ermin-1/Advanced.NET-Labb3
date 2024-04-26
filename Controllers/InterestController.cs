using Advanced.NET_Labb3.Models;
using Advanced.NET_Labb3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced.NET_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
    private IInterestRepository _interestRepository;
        public InterestController(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> GetInterestsPersonId(int personId)
        {
            var interests = await _interestRepository.GetInterestsPersonId(personId);
            try
            {
                
                if (interests == null)
                {
                    return NotFound();
                }
                return Ok(interests);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrivve interest from database!");
            }
           
          
        }
    }
}
