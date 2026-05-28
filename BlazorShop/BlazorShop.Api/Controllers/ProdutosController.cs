using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtosDtos = produtos.ConverterProdutosParaDto();
                    return Ok(produtosDtos);
                }

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter os produtos.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetItem(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetIem(id);
                if (produto is null)
                {
                    return NotFound("Erro ao localizar o produto");
                }
                else
                {
                    var produtoDto = produto.ConverterProdutoParaDto();
                    return Ok(produtoDto);
                }

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o produto.");
            }
        }

        [HttpGet]
        [Route("GetItensPorCategoria/{categoriaId:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
                var produtosDto = produtos.ConverterProdutosParaDto();
                return Ok(produtosDto);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter os produtos por categoria.");
            }
        }
    }
}
