using System.ComponentModel.DataAnnotations;

namespace Advanced.NET_Labb3.Models
{
    public class JoinTable
    {
        [Key]
        public int PersonInterestId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<Link> Links { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }

       
    }
}
