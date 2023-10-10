using TaskNumberTwo.DTOs;

namespace TaskNumberTwo.Contracts
{
    public interface IFlatService
    {
        Task<IEnumerable<FlatDto>> GetAllFlatsAsync();

        Task<int> CreateFlatAsync(FlatDto model, int houseid);

        Task UpdateFlatAsync(int id, FlatDto model);
        Task DeleteFlatAsync(int id);
    }
}
