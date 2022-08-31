using CartaoAPI.Data;
using CartaoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartaoController : Controller
    {
        private readonly CartaoDbContext _cartaoContext;
        public CartaoController(CartaoDbContext cartaoDbContext)
        {
            this._cartaoContext = cartaoDbContext;
        }

        // Get all cartoes
        [HttpGet]
        public async Task<IActionResult> GetAllCartoes()
        {
            var cartoes = await _cartaoContext.Cartoes.ToListAsync();
            return Ok(cartoes);
        }

        // Get single cartao
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCartao")]
        public async Task<IActionResult> GetCartao([FromRoute] Guid id)
        {
            var cartao = await _cartaoContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (cartao != null)
            {
                return Ok(cartao);
            }
            return NotFound("Cartao nao encontrado");
        }

        // Add cartao
        [HttpPost]
        public async Task<IActionResult> AddCartao([FromBody] Cartao cartao)
        {
            cartao.Id = Guid.NewGuid();
            await _cartaoContext.Cartoes.AddAsync(cartao);
            await _cartaoContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetCartao), new { id = cartao.Id }, cartao);
        }

        // Update Cartao
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCartao([FromRoute] Guid id, [FromBody] Cartao cartao)
        {
            var existeCartao = await _cartaoContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (existeCartao != null)
            {
                existeCartao.NomeCartao = cartao.NomeCartao;
                existeCartao.NumCartao = cartao.NumCartao;
                existeCartao.VencimentoMes = cartao.VencimentoMes;
                existeCartao.VencimentoAno = cartao.VencimentoAno;
                existeCartao.CVV = cartao.CVV;

                await _cartaoContext.SaveChangesAsync();
                return Ok(existeCartao);
            }

            return NotFound("Cartao nao encontrado");
        }

        // Delete Cartao
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCartao([FromRoute] Guid id)
        {
            var existeCartao = await _cartaoContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (existeCartao != null)
            {
                _cartaoContext.Remove(existeCartao);

                await _cartaoContext.SaveChangesAsync();
                return Ok(existeCartao);
            }

            return NotFound("Cartao nao encontrado");
        }
    }
}
