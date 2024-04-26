using Advanced.NET_Labb3.Data;
using Advanced.NET_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.NET_Labb3.Services
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddIPerson(int personId, int interest)
        {
            var personILink = new JoinTable

            {
                PersonId = personId,
                InterestId = interest
            };
            _context.JoinTables.Add(personILink);
            await _context.SaveChangesAsync();
        }

        public async Task AddLPerson(int personId, int interestId, string url)
        {
            var result = new JoinTable
            {
                PersonId = personId,
                InterestId = interestId,
                Links = new List<Link>() { new Link { Url = url } }
            };

            _context.JoinTables.Add(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Interest>> GetPInterest(int id)
        {
            var personInterest = await _context.JoinTables.Where(p => p.PersonId == id).Select(p => p.Interest).ToListAsync();

            return personInterest;
        }

        public async Task<IEnumerable<Link>> GetPLinks(int id)
        {
            return await _context.JoinTables.Where(p => p.PersonId == id).SelectMany(u => u.Links).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GettAll()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
