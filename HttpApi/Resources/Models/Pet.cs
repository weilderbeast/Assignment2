using System.ComponentModel.DataAnnotations;

namespace Assignment1.Data.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}