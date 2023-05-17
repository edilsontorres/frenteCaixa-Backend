using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using projetoCaixa.Data;
using projetoCaixa.DTOs;
using projetoCaixa.Entites;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Controllers
{

    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public ProductController(IProductRepository productRepository, DataContext context, IMapper mapper)
        {
            _productRepository = productRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct()
        {
            var teste = await _productRepository.GetProduct();
            return Ok(teste);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var productRequest = await _productRepository.GetProductById(id);
            if (productRequest != null)
            {
                var productResponse = _mapper.Map<ProductResponseDTO>(productRequest);
                return Ok(productResponse);
            }
            return NotFound("Produto não encontrado!");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Product>> NewProduct(ProductRequestDTO product)
        {
            var userBanco = await _context.Users.FindAsync(product.UserId);

            if (userBanco != null)
            {
                var newProduct = _mapper.Map<Product>(product);
                await _productRepository.NewProduct(newProduct);
                await _productRepository.SalveAllAsync();
                return Ok("Produto cadastrado com sucesso!");

            }

            return NotFound("Usuário não encontrado!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(ProductRequestDTO product, int id)
        {
            var productBanco = await _context.Products.FindAsync(id);
            if (productBanco == null) return NotFound("Produto não cadastrado!");

            var productAtualizar = _mapper.Map(product, productBanco);
            await _productRepository.UpdateProduct(productAtualizar);

            return (await _productRepository.SalveAllAsync()) 
                    ? Ok("Produto atualizado com sucesso!") 
                    : BadRequest("Erro ao atualizar o produto!");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                _productRepository.RemoveProduct(product);
                await _productRepository.SalveAllAsync();
                return Ok("Produto deletado com sucesso!");
            }
                   
            return BadRequest("Erro ao deletar produto!");
        }
    }
}
