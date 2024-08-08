using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MontyHall_be.models;

namespace MontyHall_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static Random rand = new Random();
        private static GameState currentGame;

        [HttpGet("start")]
        public ActionResult<GameState> StartGame() {
            currentGame = new GameState {
                WinningDoor = rand.Next(3),
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

        [HttpPost("finalize")]
        public ActionResult<GameState> FinalizeChoice([FromBody] bool switchDoor)
        {
            if(currentGame == null || currentGame.GameOver)
            {
                return BadRequest("Game not started or already finished.");
            }

            if(switchDoor)
            {
                currentGame.UserChoice = 3 - currentGame.UserChoice - currentGame.MontyReveal;
            }

            currentGame.GameOver = true;
            currentGame.UserWon = currentGame.UserChoice == currentGame.WinningDoor;
            return currentGame;
        }
        
    }
}
