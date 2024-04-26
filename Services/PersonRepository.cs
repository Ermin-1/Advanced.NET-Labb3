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
        public async Task AddPerson(Person person)
        {
           _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GettAll()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
