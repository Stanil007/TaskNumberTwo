using System.ComponentModel.DataAnnotations;

namespace TaskNumberTwo.DTOs
{
    public class House
    {

        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}
