using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskNumberTwo.Models.Configurations
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(CreatedHouses());
        }

        private List<House> CreatedHouses()
        {
            return new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Street = "Kosmonavtov",
                    City = "Riga",
                    Country = "Latvia",
                    PostCode = "LV6100"
                },
                new House()
                {
                    Id = 2,
                    Street = "Sumska",
                    City = "Riga",
                    Country = "Latvia",
                    PostCode = "LV6500"
                },
                new House()
                {
                    Id = 3,
                    Street = "Klochkivska",
                    City = "Riga",
                    Country = "Latvia",
                    PostCode = "LV6000"
                }
            };
        }
    }
    
    }

