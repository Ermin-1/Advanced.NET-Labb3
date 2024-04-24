using Advanced.NET_Labb3.Data;
using Advanced.NET_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.NET_Labb3.Services
{
    public class InterestRepository : IApplication
    {
        private AppDbContext _context;
        public InterestRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        public Task AddPerson(Person person)
        {
            throw new NotImplementedException();
        }


        //------- intrestrepo --------
        public async Task<IEnumerable<Interest>> GetInterestsPersonId(int personId)
        {
            return await _context.Interests.Where(i => i.Persons.FirstOrDefault(p => p.PersonId == personId) != null)
                         .ToListAsync();
        }


        public Task<IEnumerable<Link>> GetLinksIdPersonId(int personId, int interestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GettAll()
        {
            throw new NotImplementedException();
        }
    }
}
