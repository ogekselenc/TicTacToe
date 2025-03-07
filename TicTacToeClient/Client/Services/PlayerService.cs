using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using TicTacToeClient.Shared;

namespace TicTacToeClient.Client.Services
{
    public class PlayerService
    {
        private readonly HttpClient _http;
        private readonly HubConnection _hubConnection;

        public event Action? OnChange;

        public PlayerService(HttpClient http)
        {
            _http = http;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/gameHub")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On("ReceiveUpdate", () =>
            {
                OnChange?.Invoke();
            });

            _hubConnection.StartAsync();
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _http.GetFromJsonAsync<List<Player>>("api/Player");
        }

        public async Task AddPlayer(Player player)
        {
            await _http.PostAsJsonAsync("api/Player", player);
        }
    }
}
