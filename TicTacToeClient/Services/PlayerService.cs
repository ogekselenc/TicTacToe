using System.Net.Http;
using System.Threading.Tasks;

namespace TicTacToeClient.Services
{
    public class PlayerService
    {
        private readonly HttpClient _httpClient;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Define methods to interact with the backend API
        public async Task<string> GetPlayerNameAsync()
        {
            var response = await _httpClient.GetStringAsync("api/player/name");
            return response;
        }
    }
}
