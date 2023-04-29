using projetoCaixa.Entites;

namespace projetoCaixa.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> NewProduct(Product product);

        Task<Product> GetProduct(int Id);

        Task<string> UpdateProduct(Product product);

        Task<string> RemoveProduct(int Id);

        Task<bool> SalveAllAsync();
    }
}
