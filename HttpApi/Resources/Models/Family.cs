using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Data.Models
{
    public class Family
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string StreetName { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
        }
    }
}