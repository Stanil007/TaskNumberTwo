using TaskNumberTwo.DTOs;

namespace TaskNumberTwo.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseDto>> GetAllHousesAsync();

        Task<int> CreateHouseAsync(HouseDto model);

        Task UpdateHouseAsync(int id, HouseDto model);
        Task DeleteHouseAsync(int id);
    }
}
