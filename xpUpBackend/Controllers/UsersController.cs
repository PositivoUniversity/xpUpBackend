using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.Cecil.Cil;
using xpUpBackend.ContextDb;
using xpUpBackend.Dto;
using xpUpBackend.Models;

namespace xpUpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly XpUpContext _context;

        public UsersController(XpUpContext context)
        {
            _context = context;
        }
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = Enum.GetValues(typeof(UsersRoles)).Cast<UsersRoles>().Select(x => new { Id = (int)x, Name = x.ToString() });
            return Ok(roles);
        }
        // GET: api/Users
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        private string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // PUT: api/Users/editUser/{id}
        [HttpPut("editUser/{id}")]
        public async Task<IActionResult> PutDtoUser(int id, EditUsersDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dto is null.");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            user.Id = dto.Id;
            user.Name = dto.Name;
            user.PasswordTip = dto.PasswordTip;
            user.Password = dto.Password;
            user.CourseId = dto.Course;
            user.PasswordTip = dto.PasswordTip;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.Password = ComputeHash(dto.Password);
          
            }

            user.PasswordTip = dto.PasswordTip;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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


        [HttpPost("createUserDto")]
        public async Task<ActionResult<Users>> PostCreateUsers(CreateUsersDto dto)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'XpUpContext.Users' is null.");
            }

            Courses course = await _context.Courses.FindAsync(dto.Course);
            if (course == null)
            {
                return NotFound("Curso não encontrado!");
            }
            else
            {
                var users = new Users
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    PasswordTip = dto.PasswordTip,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    Role = dto.Role,
                    Course = course
                };

                users.Password = ComputeHash(dto.Password);
                users.PasswordTip = ComputeHash(dto.PasswordTip);

                _context.Users.Add(users);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsers", new { id = users.Id }, users);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'XpUpContext.Users'  is null.");
          }
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
