using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advanced.NET_Labb3.Models
{
    public class Link
    {
        [Key] 
        public int LinkId { get; set; }
        public string Url { get; set; }


        public int PersonInterestId { get; set; }
        public JoinTable joinTable { get; set; }

    }
}
