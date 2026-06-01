using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/CarrinhoCompra", carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex) { throw; }
        }

        public async  Task<CarrinhoItemDto> DeletaItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/CarrinhoCompra/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
               return default(CarrinhoItemDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CarrinhoItemDto>> GetItens(int usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/CarrinhoCompra/{usuarioId}/itens");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>() ?? new List<CarrinhoItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter itens do carrinho: {ex.Message}");
                throw;
            }
        }
    }
}
