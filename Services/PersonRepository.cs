using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public class PersonRepository : IApplication
    {
        public Task AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        public Task AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Interest>> GetInterestsPersonId(int personId)
        {
            throw new NotImplementedException();
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
