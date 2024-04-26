using Advanced.NET_Labb3.Models;
using Advanced.NET_Labb3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced.NET_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {

        private ILinkRepository _linkRepository;

        public LinksController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int personId, int interestId)
        {
            try
            {
                var links = await _linkRepository.GetLinksIdPersonId(personId, interestId);
                if (links == null)
                {
                    return NotFound();
                }
                return Ok(links);
            }
            catch (Exception)
            {

             return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrivve Links from database!");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Post(int personId, int interestId, [FromBody] Link link)
        {
            link.PersonId = personId;
            link.InterestId = interestId;
            await _linkRepository.AddLink(link);
            return CreatedAtAction("Get", new { personId = link.PersonId, interestId = link.InterestId }, link);
        }
    }
}
