using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNumberTwo.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        public int PersonalCode { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public int FlatId { get; set; }

        [Required]
        [ForeignKey(nameof(FlatId))]
        public Flat Flat { get; set; }
    }
}
