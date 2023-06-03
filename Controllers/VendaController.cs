using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data;
using projetoCaixa.DTOs;
using projetoCaixa.Entites;
using projetoCaixa.Repositories;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : Controller
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaItem _itemVenda;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public VendaController(IVendaRepository vendaRepository, DataContext context, IMapper mapper, IProductRepository productRepository, IVendaItem vendaItem)
        {
            _vendaRepository = vendaRepository;
            _context = context;
            _mapper = mapper;
            _productRepository = productRepository;
            _itemVenda = vendaItem;
        }

        [HttpPost("/itemvenda/{id}")]
        public async Task<ActionResult> AdicionarPorduto([FromRoute] int id, [FromBody] ItemVendaDTO item)
        {

            var productId = await _productRepository.GetProductById(id);
           
            if(productId != null)
            {
                var itemObj = _mapper.Map(productId, item);
                return Ok(itemObj);
                //await _itemVenda.AdicionandoProduto(itemVenda);
            }

            return BadRequest("Produto não adicionado!");
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> RealizarVenda([FromRoute] int id, [FromBody] Venda venda)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(user != null)
            {
                var newVenda = await _vendaRepository.RealizarVenda(venda);
                return Ok(newVenda);

            }

            return NotFound("Usuário não encontrado");
        }
    }
}
