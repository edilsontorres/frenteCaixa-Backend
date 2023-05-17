using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data;
using projetoCaixa.DTOs;
using projetoCaixa.Entites;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetProduct()
        {
           return await _context.Products.Select(x => new ProductResponseDTO 
                                                      { 
                                                         Id = x.Id, 
                                                         Descricao = x.Descricao, 
                                                         Estoque = x.Estoque, 
                                                         Preco = x.Preco
                                                      })
                                                      .ToListAsync();
        }
        public async Task<Product> GetProductById(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            return product!;
        }

        public async Task<Product> NewProduct(Product product)
        {
            await _context.AddAsync(product);
            return product;   
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void RemoveProduct(Product product)
        {
            _context.Remove(product);
        }

        public async Task<bool> SalveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
