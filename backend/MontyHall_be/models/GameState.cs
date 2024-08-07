namespace MontyHall_be.models
{
    public class GameState
    {
        public int WinningDoor { get; set; }
        public int UserChoice { get; set; }
        public int MontyReveal { get; set; }
        public bool GameOver { get; set; }
        public bool? UserWon { get; set; }

    }
}
