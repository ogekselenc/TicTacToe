using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TicTacToeClient.Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendUpdate()
        {
            await Clients.All.SendAsync("ReceiveUpdate");
        }
    }
}
