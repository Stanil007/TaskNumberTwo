using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Services
{

    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext dbContext;

        public PersonService(ApplicationDbContext _context)
        {
            dbContext = _context;
        }

        public async Task<int> CreatePersonAsync(PersonDto model, int flatid)
        {
            var person = new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PersonalCode = model.PersonalCode,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                FlatId = flatid
            };

            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            try
            {
                await dbContext.Persons.AddAsync(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error while creating person");
            }

            return person.Id;
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Persons.Remove(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            var persons = await dbContext.Persons.Select(x => new PersonDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalCode = x.PersonalCode,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                FlatId = x.FlatId
            })
             .ToListAsync();

            return persons;
        }

        public async Task UpdatePersonAsync(int id, PersonDto model)
        {
            var person = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                throw new ArgumentNullException();
            }

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.PersonalCode = model.PersonalCode;
            person.DateOfBirth = model.DateOfBirth;
            person.PhoneNumber = model.PhoneNumber;
            person.Email = model.Email;
            person.FlatId = model.FlatId;

            await dbContext.SaveChangesAsync();
        }
    }
}
