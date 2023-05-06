﻿using projetoCaixa.Data;
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
        public Task<Product> GetProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> NewProduct(Product product)
        {
            await _context.AddAsync(product);
            return product;   
        }

        public Task<string> RemoveProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SalveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<string> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
