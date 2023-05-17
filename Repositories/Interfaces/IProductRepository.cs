using projetoCaixa.DTOs;
using projetoCaixa.Entites;

namespace projetoCaixa.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponseDTO>> GetProduct();
        
        Task<Product> NewProduct(Product product);

        Task<Product> GetProductById(int Id);

        Task UpdateProduct(Product product);

        public void RemoveProduct(Product product);

        Task<bool> SalveAllAsync();
    }
}
