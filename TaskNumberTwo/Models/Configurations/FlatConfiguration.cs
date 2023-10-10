using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Models.Configurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
           // builder.HasData(CreatedFlats());
        }

        private List<Flat> CreatedFlats()
        {
            return new List<Flat>()
            {
                new Flat()
                {
                    Id = 1,
                    Floor = 1,
                    Rooms = 3,
                    Inhabitants = 2,
                    TotalArea = 80.0,
                    LivingArea = 60.0,
                    HouseId = 1
                },
                new Flat()
                {
                    Id = 2,
                    Floor = 2,
                    Rooms = 2,
                    Inhabitants = 1,
                    TotalArea = 60.0,
                    LivingArea = 40.0,
                    HouseId = 1
                },
                new Flat()
                {
                    Id = 3,
                    Floor = 3,
                    Rooms = 1,
                    Inhabitants = 1,
                    TotalArea = 40.0,
                    LivingArea = 30.0,
                    HouseId = 1
                },
                new Flat()
                {
                    Id = 4,
                    Floor = 5,
                    Rooms = 4,
                    Inhabitants = 3,
                    TotalArea = 100.0,
                    LivingArea = 80.0,
                    HouseId = 2
                },
                new Flat()
                {
                    Id = 5,
                    Floor = 4,
                    Rooms = 3,
                    Inhabitants = 2,
                    TotalArea = 80.0,
                    LivingArea = 60.0,
                    HouseId = 2
                }
            };
        }
    }
}