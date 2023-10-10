using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService flatService;
        private readonly ApplicationDbContext dbContext;

        public FlatController(IFlatService _flatService, ApplicationDbContext _dbContext)
        {
            flatService = _flatService;
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlatsAsync()
        {
            var flats = await flatService.GetAllFlatsAsync();
            return Ok(flats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlatAsync(FlatDto model, int houseid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = await dbContext.Houses.FirstOrDefaultAsync(x => x.Id == houseid);

            if (house == null)
            {
                return NotFound();
            }

            var flatid = await flatService.CreateFlatAsync(model, houseid);
            return Created($"house/{flatid}", null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlatAsync(int id)
        {
            await flatService.DeleteFlatAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlatAsync(int id, FlatDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flat = await dbContext.Flats.FirstOrDefaultAsync(x => x.Id == id);

            if (flat == null)
            {
                return NotFound();
            }

            await flatService.UpdateFlatAsync(id, model);
            return NoContent();
        }
    }
}
