using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNumberTwo.Models
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }

        public int Floor { get; set; }

        public int Rooms { get; set; }

        public int Inhabitants { get; set; }

        public double TotalArea { get; set; }

        public double LivingArea { get; set; }

        public int HouseId { get; set; }

        [Required]
        [ForeignKey(nameof(HouseId))]
        public House House { get; set; }
    }
}
