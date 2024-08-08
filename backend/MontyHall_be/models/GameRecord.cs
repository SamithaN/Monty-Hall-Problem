namespace MontyHall_be.models
{
    public class GameRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool UserWon { get; set; }
        public int UserChoice { get; set; }
        public int WinningDoor { get; set; }
    }
}
