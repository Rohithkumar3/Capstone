using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject1.Models
{
    [Table("AdminInfo")]
    public class AdminInfocs
    {
        [Key]
        public int AdminId { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
    }
}
