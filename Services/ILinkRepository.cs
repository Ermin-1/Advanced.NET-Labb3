using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public interface ILinkRepository
    {

        Task <IEnumerable<Link>> GetLinksIdPersonId(int personId, int interestId);
        Task AddLink(Link link);
    }
}

