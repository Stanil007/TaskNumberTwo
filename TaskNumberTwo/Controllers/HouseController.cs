using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService houseService;
        private readonly ApplicationDbContext dbContext;

        public HouseController(IHouseService _houseService, ApplicationDbContext _dbContext)
        {
            houseService = _houseService;
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHousesAsync()
        {
            var houses = await houseService.GetAllHousesAsync();
            return Ok(houses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouseAsync(HouseDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var houseid = await houseService.CreateHouseAsync(model);
            return Created($"house/{houseid}",null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHouseAsync(int id)
        {
            await houseService.DeleteHouseAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHouseAsync(int id, HouseDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = await dbContext.Houses.FirstOrDefaultAsync(x => x.Id == id);

            if (house == null)
            {
                return NotFound();
            }

            await houseService.UpdateHouseAsync(id, model);
            return NoContent();
        }
    }
}
