using TaskNumberTwo.Models;

namespace TaskNumberTwo.Contracts
{
    public interface IPersonService
    {
       Task<IEnumerable<Person>> GetAllPersonsAsync();

        Task<Person> CreatePersonAsync();

        Task<Person> UpdatePersonAsync();

        Task DeletePersonAsync(int id);
    }
}
