
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using xpUpBackend.ContextDb;
using xpUpBackend.Dto;
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

            var likes = await _context.Likes
                .Include(l => l.LikedBy)
                .Include(l => l.Notice)
                .Include(l => l.Event)
                .ToListAsync();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var jsonResult = JsonSerializer.Serialize(likes, jsonOptions);

            return new ContentResult
            {
                Content = jsonResult,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Likes>> GetLikes(int id)
        {
            if (_context.Likes == null)
            {
                return NotFound();
            }

            var likes = await _context.Likes
                .Where(l => l.Id == id)
                .Include(l => l.LikedBy)
                .Include(l => l.Notice)
                .Include(l => l.Event)
                .FirstOrDefaultAsync();

            if (likes == null)
            {
                return NotFound();
            }

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var jsonResult = JsonSerializer.Serialize(likes, jsonOptions);

            return new ContentResult
            {
                Content = jsonResult,
                ContentType = "application/json",
                StatusCode = 200
            };
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
        [HttpPost("createLikesDto")]
        public async Task<ActionResult<Likes>> PostLikes(CreateLikesDto likesDTO)
        {
            var eventId = await _context.Events.FindAsync(likesDTO.EventId);
            var newsId = await _context.News.FindAsync(likesDTO.NoticeId);
            var userId = await _context.Users.FindAsync(likesDTO.LikedByUserId);
            if (_context.Likes == null)
            {
                return Problem("Entity set 'XpUpContext.Likes' is null.");
            }
            if(eventId  != null)
            {
                var likesEvent = new Likes
                {
                    Like = likesDTO.Like,
                    LikedBy = userId,
                    Event = eventId,
                };

                _context.Likes.Add(likesEvent);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLikes", new { id = likesDTO.Id }, likesDTO);
            }
                
            if (newsId != null)
            {
                var likesNotice = new Likes
                {
                    Like = likesDTO.Like,
                    LikedBy = userId,
                    Notice = newsId
                };
                _context.Likes.Add(likesNotice);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLikes", new { id = likesDTO.Id }, likesDTO);
            }
            return Problem("Erro eventos dtoLikes");
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
