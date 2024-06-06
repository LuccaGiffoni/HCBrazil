using HCBrazil.Api.Data;
using HCBrazil.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCBrazil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardiansController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guardian>>> GetGuardians()
        {
            return await context.Guardians.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guardian>> GetGuardian(Guid id)
        {
            var guardian = await context.Guardians.FindAsync(id);

            if (guardian == null)
            {
                return NotFound();
            }

            return guardian;
        }

        [HttpPost]
        public async Task<ActionResult<Guardian>> PostGuardian(Guardian guardian)
        {
            context.Guardians.Add(guardian);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuardian), new { id = guardian.Id }, guardian);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardian(Guid id, Guardian guardian)
        {
            if (id != guardian.Id)
            {
                return BadRequest();
            }

            context.Entry(guardian).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuardianExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardian(Guid id)
        {
            var guardian = await context.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return NotFound();
            }

            context.Guardians.Remove(guardian);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuardianExists(Guid id)
        {
            return context.Guardians.Any(e => e.Id == id);
        }
    }
}