using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Services
{
    public class FlatService : IFlatService
    {
        private readonly ApplicationDbContext dbContext;

        public FlatService(ApplicationDbContext _context)
        {
            dbContext = _context;
        }

        public async Task<int> CreateFlatAsync(FlatDto model, int houseid)
        {
            var flat = new Flat()
            {
                Floor = model.Floor,
                Rooms = model.Rooms,
                Inhabitants = model.Inhabitants,
                HouseId = houseid,
                TotalArea = model.TotalArea,
                LivingArea = model.LivingArea
            };

            if (flat == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                await dbContext.Flats.AddAsync(flat);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error while creating flat");
            }

            return flat.Id;
        }

        public async Task DeleteFlatAsync(int id)
        {
            var flat = await dbContext.Flats.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Flats.Remove(flat);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlatDto>> GetAllFlatsAsync()
        {
            var flats = await dbContext.Flats.Select(x => new FlatDto()
            {
                Id = x.Id,
                Floor = x.Floor,
                Rooms = x.Rooms,
                Inhabitants = x.Inhabitants,
                TotalArea = x.TotalArea,
                LivingArea = x.LivingArea,
                HouseId = x.HouseId
            })
             .ToListAsync();

            return flats;
        }

        public async Task UpdateFlatAsync(int id, FlatDto model)
        {
            var flat = await dbContext.Flats.FirstOrDefaultAsync(x => x.Id == id);

            if (flat == null)
            {
                throw new ArgumentNullException();
            }

            flat.Floor = model.Floor;
            flat.Rooms = model.Rooms;
            flat.Inhabitants = model.Inhabitants;
            flat.HouseId = model.HouseId;
            flat.TotalArea = model.TotalArea;
            flat.LivingArea = model.LivingArea;

            await dbContext.SaveChangesAsync();
        }
}
}
