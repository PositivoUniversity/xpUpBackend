using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xpUpBackend.ContextDb;
using xpUpBackend.Dto;
using xpUpBackend.Migrations;
using xpUpBackend.Models;

namespace xpUpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly XpUpContext _context;

        public LikesController(XpUpContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Likes>>> GetLikes()
        {
          if (_context.Likes == null)
          {
              return NotFound();
          }
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Likes>> GetLikes(int id)
        {
          if (_context.Likes == null)
          {
              return NotFound();
          }
            var likes = await _context.Likes.FindAsync(id);

            if (likes == null)
            {
                return NotFound();
            }

            return likes;
        }

        // PUT: api/Likes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikes(int id, Likes likes)
        {
            if (id != likes.Id)
            {
                return BadRequest();
            }

            _context.Entry(likes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikesExists(id))
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

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("dtoLikes")]
        public async Task<ActionResult<Likes>> PostLikes(CreateLikesDto likesDTO)
        {
            var eventId = await _context.Users.FindAsync(likesDTO.EventId);
            var newsId = await _context.Users.FindAsync(likesDTO.NoticeId);
            if (_context.Likes == null)
            {
                return Problem("Entity set 'XpUpContext.Likes' is null.");
            }
            //likes sem notice
            if(newsId  == null)
            {
                var likesEvent = new Likes
                {
                    Like = likesDTO.Like,
                    LikedBy = await _context.Users.FindAsync(likesDTO.LikedByUserId),
                    Event = await _context.Events.FindAsync(likesDTO.EventId),
                };

                _context.Likes.Add(likesEvent);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLikes", new { id = likesEvent.Id }, likesEvent);
            }

            //notice sem event
            if (eventId == null)
            {
                var likesNotice = new Likes
                {
                    Like = likesDTO.Like,
                    LikedBy = await _context.Users.FindAsync(likesDTO.LikedByUserId),
                    Notice = await _context.News.FindAsync(likesDTO.NoticeId)
                };
                _context.Likes.Add(likesNotice);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLikes", new { id = likesNotice.Id }, likesNotice);
            }
            //likes com os 2
            if(eventId != null && newsId != null)
            {
                var likesAll = new Likes
                {
                    Like = likesDTO.Like,
                    LikedBy = await _context.Users.FindAsync(likesDTO.LikedByUserId),
                    Notice = await _context.News.FindAsync(likesDTO.NoticeId),
                    Event = await _context.Events.FindAsync(likesDTO.EventId)
                };

                _context.Likes.Add(likesAll);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLikes", new { id = likesDTO.Id }, likesDTO);
            }
            return Problem("Error não capturado");
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikes(int id)
        {
            if (_context.Likes == null)
            {
                return NotFound();
            }
            var likes = await _context.Likes.FindAsync(id);
            if (likes == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(likes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikesExists(int id)
        {
            return (_context.Likes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
