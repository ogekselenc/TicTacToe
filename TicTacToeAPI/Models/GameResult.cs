using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class GameResult
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int BoardSize { get; set; }
        public int WinLength { get; set; }
        public bool IsWinner { get; set; }
    }
}
