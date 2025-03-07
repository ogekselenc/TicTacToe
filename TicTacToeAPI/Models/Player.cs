using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
