using System.ComponentModel.DataAnnotations;

namespace Advanced.NET_Labb3.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<Person> Persons { get; set; } = new List<Person>();
        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
