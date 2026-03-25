using System.Net.Http.Json;
using System.Text.Json;

using BlazorClientesNet8.Shared.Interfaces;
using BlazorClientesNet8.Shared.Entities;

namespace BlazorClientesNet10.Client.Service
{
    public class ClienteService : IClienteRepository
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions _options;

        public ClienteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task<Cliente> AddClienteAsync(Cliente model)
        {
            var cliente = await httpClient.PostAsJsonAsync("api/Cliente/Add-Cliente", model);
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<Cliente> DeleteClienteAsync(int clienteId)
        {
            var cliente = await httpClient.DeleteAsync($"api/Cliente/Delete-Cliente/{clienteId}");
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            var response = await httpClient.GetAsync("api/Cliente/Clientes");

            if (!response.IsSuccessStatusCode)
            {
                // Se cair aqui, a API retornou erro (404, 500, etc)
                var conteudoErro = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"ERRO NA API: {response.StatusCode}");
                Console.WriteLine($"CONTEÚDO RECEBIDO: {conteudoErro.Substring(0, Math.Min(100, conteudoErro.Length))}");
                return new List<Cliente>();
            }

            return await response.Content.ReadFromJsonAsync<List<Cliente>>() ?? new List<Cliente>();


            //var clientes = await httpClient.GetAsync("api/Cliente/Clientes");
            //var response = await clientes.Content.ReadFromJsonAsync<List<Cliente>>();
            //return response!;
        }

        public async Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            var cliente = await httpClient.GetAsync($"api/Cliente/Cliente/{clienteId}");
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente model)
        {
            var cliente = await httpClient.PutAsJsonAsync("api/Cliente/Update-Cliente", model);
            var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return response!;
        }
    }
}