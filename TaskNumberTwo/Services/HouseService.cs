using Microsoft.EntityFrameworkCore;
using System;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Services
{
    public class HouseService : IHouseService
    {
        private readonly ApplicationDbContext dbContext;

        public HouseService(ApplicationDbContext _context)
        {
            dbContext = _context;
        }

        public async Task<int> CreateHouseAsync(HouseDto model)
        {
            var house = new House()
            {
                Street = model.Street,
                City = model.City,
                Country = model.Country,
                PostCode = model.PostCode
            };

            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            }

            try
            {
               await dbContext.Houses.AddAsync(house);
               await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error while creating house");
            }

            return house.Id;
        }

        public async Task DeleteHouseAsync(int id)
        {
            var house = await dbContext.Houses.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Houses.Remove(house);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HouseDto>> GetAllHousesAsync()
        {
            var houses = await dbContext.Houses.Select(x => new HouseDto()
            {
                Id = x.Id,
                Street = x.Street,
                City = x.City,
                Country = x.Country,
                PostCode = x.PostCode
            }).ToListAsync();

            return houses;
        }

        public async Task UpdateHouseAsync(int id, HouseDto model)
        {
            var house = await dbContext.Houses.FirstOrDefaultAsync(x => x.Id == id);

            if (house == null)
            {
                throw new ArgumentNullException();
            }

            house.Street = model.Street;
            house.City = model.City;
            house.Country = model.Country;
            house.PostCode = model.PostCode;

            await dbContext.SaveChangesAsync();
        }
    }
}
