﻿using System;
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
    public class EventsController : ControllerBase
    {
        private readonly XpUpContext _context;

        public EventsController(XpUpContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetEvents()
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEvents(int id)
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            var events = await _context.Events.FindAsync(id);

            if (events == null)
            {
                return NotFound();
            }

            return events;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, Events events)
        {
            if (id != events.Id)
            {
                return BadRequest();
            }

            _context.Entry(events).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Events>> PostEvents(Events events)
        {
          if (_context.Events == null)
          {
              return Problem("Entity set 'XpUpContext.Events'  is null.");
          }
            _context.Events.Add(events);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = events.Id }, events);
        }

        [HttpPost("createEventsDto")]
        public async Task<ActionResult> PostCreateEvents(CreateEventsDto dto)
        {
            if (dto == null)
            {
                return BadRequest("O DTO de criação de eventos é inválido.");
            }
            var eventToAdd = new Events
            {
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Description = dto.Description,
                UsersId = dto.UsersId,
                UserPost = dto.userPost,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            _context.Events.Add(eventToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = eventToAdd.Id }, eventToAdd);
        }


// DELETE: api/Events/5
[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }

            _context.Events.Remove(events);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventsExists(int id)
        {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
