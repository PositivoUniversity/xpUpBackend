using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xpUpBackend.ContextDb;
using xpUpBackend.Dto;
using xpUpBackend.Models;

namespace xpUpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInsController : ControllerBase
    {
        private readonly XpUpContext _context;

        public CheckInsController(XpUpContext context)
        {
            _context = context;
        }

        // GET: api/CheckIns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckIn>>> GetCheckIn()
        {
          if (_context.CheckIn == null)
          {
              return NotFound();
          }
            return await _context.CheckIn.ToListAsync();
        }

        // GET: api/CheckIns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckIn>> GetCheckIn(int id)
        {
          if (_context.CheckIn == null)
          {
              return NotFound();
          }
            var checkIn = await _context.CheckIn.FindAsync(id);

            if (checkIn == null)
            {
                return NotFound();
            }

            return checkIn;
        }

        // PUT: api/CheckIns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckIn(int id, CheckIn checkIn)
        {
            if (id != checkIn.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
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

        // POST: api/CheckIns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckIn>> PostCheckIn(CreateCheckinsDto checkInDto)
        {
            if (_context.CheckIn == null)
            {
                return Problem("Entity set 'XpUpContext.CheckIn' is null.");
            }

            // Mapeia o DTO de CheckIn para a entidade CheckIn
            var checkIn = new CheckIn
            {
                Check = checkInDto.Check,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CheckedBy = await _context.Users.FindAsync(checkInDto.CheckedById),
                Event = await _context.Events.FindAsync(checkInDto.EventId),
            };

            _context.CheckIn.Add(checkIn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckIn", new { id = checkIn.Id }, checkIn);
        }

        // DELETE: api/CheckIns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckIn(int id)
        {
            if (_context.CheckIn == null)
            {
                return NotFound();
            }
            var checkIn = await _context.CheckIn.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            _context.CheckIn.Remove(checkIn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckInExists(int id)
        {
            return (_context.CheckIn?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
