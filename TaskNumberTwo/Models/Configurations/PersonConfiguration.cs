using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskNumberTwo.Models.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
          //  builder.HasData(CreatedPeople());
        }

        private List<Person> CreatedPeople()
        {
            var people = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    PersonalCode = "123456-78910",
                    DateOfBirth = "20.04.1998",
                    PhoneNumber = "12345678",
                    Email = "john-smith@mail.com",
                    FlatId = 1
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PersonalCode = "123456-78915",
                    DateOfBirth = "10.07.1997",
                    PhoneNumber = "12345678",
                    Email = "jane-smith@mail.com",
                    FlatId = 2
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    PersonalCode = "123456-78911",
                    DateOfBirth = "07.02.2001",
                    PhoneNumber = "12345678",
                    Email = "john-doe@mail.com",
                    FlatId = 3
                },
                new Person()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    PersonalCode = "123456-78917",
                    DateOfBirth = "15.12.1999",
                    PhoneNumber = "12345678",
                    Email = "jane-doe@mail.com",
                    FlatId = 4
                }
            };

            return people;
        }
    }
}
