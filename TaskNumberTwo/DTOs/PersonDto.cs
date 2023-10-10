using System.ComponentModel.DataAnnotations;

namespace TaskNumberTwo.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PersonalCode { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(10)]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int FlatId { get; set; }
    }
}
