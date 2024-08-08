using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontyHall_be.Data;
using MontyHall_be.DTOs;
using MontyHall_be.models;

namespace MontyHall_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Username == dto.Username))
            {
                return BadRequest("Username already exists");
            }

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                GameRecords = new List<GameRecord>()
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(RegisterDto dto)
        {
            var existingUser = _context.Users
                .Include(u => u.GameRecords)
                .FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);

            if (existingUser == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return existingUser;
        }
    }


}
