using HCBrazil.Api.Data;
using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCBrazil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendees()
        {
            return await context.Attendees.Include(a => a.Guardian).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendee(Guid id)
        {
            var attendee = await context.Attendees.Include(a => a.Guardian).FirstOrDefaultAsync(a => a.Id == id);

            if (attendee == null)
            {
                return NotFound();
            }

            return attendee;
        }
        
        [HttpPost("CreateWithNewGuardian")]
        public async Task<ActionResult<Attendee>> PostAttendeeWithNewGuardian(CreateAttendeeWithNewGuardianRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guardian = new Guardian
            {
                FirstName = request.Guardian.FirstName,
                LastName = request.Guardian.LastName,
                Phone = request.Guardian.Phone,
                Email = request.Guardian.Email,
                RG = request.Guardian.RG,
                CPF = request.Guardian.CPF,
                Country = request.Guardian.Country,
                State = request.Guardian.State,
                City = request.Guardian.City,
                Street = request.Guardian.Street,
                Region = request.Guardian.Region,
                PostalCode = request.Guardian.PostalCode,
                Number = request.Guardian.Number
            };

            context.Guardians.Add(guardian);
            await context.SaveChangesAsync();

            var attendee = new Attendee
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Instagram = request.Instagram,
                RG = request.RG,
                CPF = request.CPF,
                Country = request.Country,
                State = request.State,
                City = request.City,
                Street = request.Street,
                Region = request.Region,
                PostalCode = request.PostalCode,
                Number = request.Number,
                GuardianId = guardian.Id
            };

            context.Attendees.Add(attendee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendee), new { id = attendee.Id }, attendee);
        }

        [HttpPost("CreateWithExistingGuardian")]
        public async Task<ActionResult<Attendee>> PostAttendeeWithExistingGuardian(CreateAttendeeWithExistingGuardianRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGuardian = await context.Guardians.FindAsync(request.GuardianId);
            if (existingGuardian == null)
            {
                return NotFound("Guardian not found");
            }

            var attendee = new Attendee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Instagram = request.Instagram,
                RG = request.RG,
                CPF = request.CPF,
                Country = request.Country,
                State = request.State,
                City = request.City,
                Street = request.Street,
                Region = request.Region,
                PostalCode = request.PostalCode,
                Number = request.Number,
                GuardianId = request.GuardianId
            };

            context.Attendees.Add(attendee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendee), new { id = attendee.Id }, attendee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendee(Guid id, Attendee attendee)
        {
            if (id != attendee.Id)
            {
                return BadRequest();
            }

            context.Entry(attendee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
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
        public async Task<IActionResult> DeleteAttendee(Guid id)
        {
            var attendee = await context.Attendees.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }

            context.Attendees.Remove(attendee);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendeeExists(Guid id)
        {
            return context.Attendees.Any(e => e.Id == id);
        }
    }
}
