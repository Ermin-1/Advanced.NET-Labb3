using Advanced.NET_Labb3.Data;
using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GettAll();
        Task<IEnumerable<Link>> GetPLinks(int id);
        Task<IEnumerable<Interest>> GetPInterest(int id);
        


        Task AddIPerson(int personID, int interest);
        Task AddLPerson(int personId, int interestID, string url);

    }

}
