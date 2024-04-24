using System.ComponentModel.DataAnnotations;

namespace Advanced.NET_Labb3.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
    }
}
