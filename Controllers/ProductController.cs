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

        [HttpPost]
        public async Task<ActionResult<Product>> NewProduct(ProductDTO product)
        {
            var userBanco = await _context.Users.FindAsync(product.UserId);

            if (userBanco == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            var newProduct = _mapper.Map<Product>(product);

            await _productRepository.NewProduct(newProduct);
            await _productRepository.SalveAllAsync();

            
            return Ok(newProduct);
        }
    }
}
