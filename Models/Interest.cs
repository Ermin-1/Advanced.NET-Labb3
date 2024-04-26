using System.ComponentModel.DataAnnotations;

namespace Advanced.NET_Labb3.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string InterestTitle { get; set; }
        public string InterestDescription { get; set; }


        public ICollection<JoinTable> JoinTables { get; set; }
  
    }
}
