using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public interface IApplication
    {
        Task<IEnumerable<Person>> GettAll();
        Task AddPerson(Person person);


        Task <IEnumerable<Interest>> GetInterestsPersonId(int personId);

        Task <IEnumerable<Link>> GetLinksIdPersonId(int personId, int interestId);
        Task AddLink(Link link);
    }

}
