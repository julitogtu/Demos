using System;
using System.Threading.Tasks;
using AspnetCorePatch.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCorePatch.Controllers
{
    [Route("api/heroes")]
    public class HeroesController : Controller
    {
        private readonly DemoDbContext dbContext;

        public HeroesController(DemoDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var heroes = await dbContext.Heroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<Hero> updateHeroPatch)
        {
            var currentHero = await dbContext.Heroes.FirstOrDefaultAsync(c => c.Id == id);

            if (currentHero is null) return NotFound();

            updateHeroPatch.ApplyTo(currentHero);

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}