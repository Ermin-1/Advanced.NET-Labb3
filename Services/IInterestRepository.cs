using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public interface IInterestRepository
    {

        Task<IEnumerable<Interest>> GetInterestsPersonId(int personId);
    }
}
