using Advanced.NET_Labb3.Models;

namespace Advanced.NET_Labb3.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GettAll();
        Task AddPerson(Person person);
    }

}
