using System.ComponentModel.DataAnnotations;

namespace Assignment1.Data.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}