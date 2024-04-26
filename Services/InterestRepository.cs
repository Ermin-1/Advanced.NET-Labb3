using Advanced.NET_Labb3.Data;
using Advanced.NET_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.NET_Labb3.Services
{
    public class InterestRepository : IInterestRepository
    {

        private AppDbContext _context;
        public InterestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Interest>> GetInterestsPersonId(int personId)
        {
            return await _context.Interests.Where(i => i.Persons.Any(p => p.PersonId == personId)).ToListAsync();   
        }
    }
}
