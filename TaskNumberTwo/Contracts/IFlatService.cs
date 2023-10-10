using TaskNumberTwo.Models;

namespace TaskNumberTwo.Contracts
{
    public interface IFlatService
    {
        Task<IEnumerable<Flat>> GetAllFlatsAsync();

        Task<Flat> CreateFlatAsync();

        Task<Flat> UpdateFlatAsync();
        Task DeleteFlatAsync(int id);
    }
}
