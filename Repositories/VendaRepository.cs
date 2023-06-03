using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data;
using projetoCaixa.Entites;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Venda> RealizarVenda(Venda venda)
        {
           await _context.AddAsync(venda);
           return venda;
        }

        public void CancelarVenda(int id)
        {
           
        }

      
    }
}
