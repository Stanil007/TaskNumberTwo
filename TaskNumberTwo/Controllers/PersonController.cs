using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Contracts;
using TaskNumberTwo.DTOs;
using TaskNumberTwo.Models;

namespace TaskNumberTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly ApplicationDbContext dbContext;

       public PersonController(IPersonService _personService, ApplicationDbContext _dbContext)
        {
            personService = _personService;
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonsAsync()
        {
            var persons = await personService.GetAllPersonsAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync(PersonDto model, int flatid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flat = await dbContext.Flats.FirstOrDefaultAsync(x => x.Id == flatid);

            if (flat == null)
            {
                return NotFound();
            }

            var personId = await personService.CreatePersonAsync(model, flatid);
            return Created($"person/{personId}", null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            await personService.DeletePersonAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonAsync(int id, PersonDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            await personService.UpdatePersonAsync(id, model);
            return NoContent();
        }

    }
}
