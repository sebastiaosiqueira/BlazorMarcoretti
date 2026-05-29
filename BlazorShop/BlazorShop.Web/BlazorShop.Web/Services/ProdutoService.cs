using Azure;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient;
        public ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ProdutoDto> GetItem(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProdutoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Erro ao obter o produto. Status Code: {StatusCode}, Message: {Message}", response.StatusCode, message);
                    throw new Exception($"Status Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exceção ao obter o produto com ID {Id}.", id);
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");
                return produtosDto;

            }
            catch (Exception) { }
            {
                _logger.LogError("Erro ao obter os produtos.");
                return Enumerable.Empty<ProdutoDto>();
            }
           
        }
    }
}
