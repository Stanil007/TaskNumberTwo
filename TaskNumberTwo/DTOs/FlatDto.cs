using System.ComponentModel.DataAnnotations;

namespace TaskNumberTwo.DTOs
{
    public class FlatDto
    {

        public int Id { get; set; }


        [Range(1,1000)]
        public int Floor { get; set; }

        [Range(1, 100)]
        public int Rooms { get; set; }

        [Range(1, 100)]
        public int Inhabitants { get; set; }

        [Range(10, 1000000)]
        public double TotalArea { get; set; }

        [Range(10, 1000000)]
        public double LivingArea { get; set; }

        public int HouseId { get; set; }
    }
}
