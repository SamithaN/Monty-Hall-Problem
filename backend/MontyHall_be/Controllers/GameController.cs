using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontyHall_be.Data;
using MontyHall_be.models;

namespace MontyHall_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext _context;
        private static Random rand = new Random();
        private static GameState currentGame;

        public GameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("start")]
        public ActionResult<GameState> StartGame() {
            currentGame = new GameState {
                WinningDoor = rand.Next(1, 4),
                GameOver = false,
            };

            return currentGame;
        }

        [HttpPost("choose")]
        public ActionResult<GameState> ChooseDoor([FromBody] int door) {
            if (currentGame == null || currentGame.GameOver)
            {
                return BadRequest("Game not started or already finished");
            }

            currentGame.UserChoice = door;

            do
            {
                currentGame.MontyReveal = rand.Next(3);
            } while (currentGame.MontyReveal == currentGame.WinningDoor || currentGame.MontyReveal == currentGame.UserChoice);

            return currentGame;
        }

        [HttpPost("finalize/{userId}")]
        public async Task<ActionResult<GameState>> FinalizeChoice(int userId, [FromBody] bool switchDoor)
        {
            if (currentGame == null || currentGame.GameOver)
            {
                return BadRequest("Game not started or already finished.");
            }

            if (switchDoor)
            {
                currentGame.UserChoice = 3 - currentGame.UserChoice - currentGame.MontyReveal;
            }

            currentGame.GameOver = true;
            currentGame.UserWon = currentGame.UserChoice == currentGame.WinningDoor;

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.GameRecords == null)
            {
                user.GameRecords = new List<GameRecord>();
            }

            user.GameRecords.Add(new GameRecord
            {
                Date = DateTime.Now,
                UserWon = currentGame.UserWon.Value,
                UserChoice = currentGame.UserChoice,
                WinningDoor = currentGame.WinningDoor
            });

            await _context.SaveChangesAsync();

            return currentGame;
        }

        [HttpGet("history/{userId}")]
        public async Task<ActionResult<IEnumerable<GameRecord>>> GetGameHistory(int userId)
        {
            var user = await _context.Users
                .Include(u => u.GameRecords)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user.GameRecords);
        }

    }
}
