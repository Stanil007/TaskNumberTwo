using TaskNumberTwo.Models;

namespace TaskNumberTwo.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<House>> GetAllHousesAsync();

        Task<House> CreateHouseAsync();

        Task<House> UpdateHouseAsync();
        Task DeleteHouseAsync(int id);
    }
}
