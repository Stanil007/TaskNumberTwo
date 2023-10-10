using System.ComponentModel.DataAnnotations;

namespace TaskNumberTwo.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostCode { get; set; }

        public List<Flat> Flats { get; set; } = new List<Flat>();
    }
}
