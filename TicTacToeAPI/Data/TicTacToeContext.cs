using Microsoft.EntityFrameworkCore;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    public class TicTacToeContext : DbContext
    {
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
    }
}
