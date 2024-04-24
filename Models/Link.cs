using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advanced.NET_Labb3.Models
{
    public class Link
    {
        [Key] 
        public int LinkId { get; set; }
        public string Url { get; set; }


        [ForeignKey("InterestId")]
        public int InterestId { get; set; }
        public Interest Interest { get; set; }


        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
