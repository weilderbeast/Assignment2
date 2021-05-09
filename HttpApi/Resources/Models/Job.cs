using System.ComponentModel.DataAnnotations;

namespace Assignment1.Data.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}