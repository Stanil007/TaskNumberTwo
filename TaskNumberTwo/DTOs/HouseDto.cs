using System.ComponentModel.DataAnnotations;

namespace TaskNumberTwo.DTOs
{
    public class HouseDto
    {

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Street { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MinLength(6)]
        public string PostCode { get; set; }
    }
}
