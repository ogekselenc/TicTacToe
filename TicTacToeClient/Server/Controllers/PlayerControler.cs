using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TicTacToeClient.Server.Data;
using TicTacToeClient.Server.Hubs;
using TicTacToeClient.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicTacToeClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly TicTacToeContext _context;
        private readonly IHubContext<GameHub> _hubContext;

        public PlayerController(TicTacToeContext context, IHubContext<GameHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.AsNoTracking().ToListAsync(); // Optimizacija: AsNoTracking()
        }

        // POST: api/Player
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                return BadRequest("Player name cannot be empty."); // Validacija unosa
            }

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveUpdate");

            return CreatedAtAction(nameof(GetPlayers), new { id = player.Id }, player);
        }
    }
}
