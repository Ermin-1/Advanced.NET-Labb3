using Advanced.NET_Labb3.Data;
using Advanced.NET_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.NET_Labb3.Services
{
    public class LinkRepository : ILinkRepository
    {
        private AppDbContext _context;
        public LinkRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddLink(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksIdPersonId(int personId, int interestId)
        {
            return await _context.Links.Where(l => l.PersonId == personId && l.InterestId == interestId).ToListAsync();
        }
    }
}
