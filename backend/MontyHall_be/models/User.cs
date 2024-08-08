using System.ComponentModel.DataAnnotations;

namespace MontyHall_be.models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public List<GameRecord> GameRecords { get; set; }
    }
}
