using TaskNumberTwo.DTOs;

namespace TaskNumberTwo.Contracts
{
    public interface IPersonService
    {
       Task<IEnumerable<PersonDto>> GetAllPersonsAsync();

        Task<int> CreatePersonAsync(PersonDto model, int flatid);

        Task UpdatePersonAsync(int id, PersonDto model);

        Task DeletePersonAsync(int id);


    }
}
