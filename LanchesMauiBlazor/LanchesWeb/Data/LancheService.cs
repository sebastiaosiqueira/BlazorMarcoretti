using LanchesLibrary;
using LanchesLibrary.Data;

namespace LanchesWeb.Data
{
    public class LancheService : ILancheService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<IEnumerable<Lanche>>? LoadLanchesAsync()
        {
            var lanches = await _httpClient.GetFromJsonAsync<List<Lanche>>(
                "https://www.macoratti.net/Sistemas/lanches.json");
            return lanches!.ToList();
        }
    }
}
