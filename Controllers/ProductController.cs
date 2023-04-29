using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoCaixa.Entites;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Controllers
{

    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> NewProduct([FromBody] Product product)
        {
            await _productRepository.NewProduct(product);

            if (await _productRepository.SalveAllAsync())
            {
                return Ok("Produto cadastrado com sucesso!");
            }
            return BadRequest("Algo deu errado!");
        }
    }
}
