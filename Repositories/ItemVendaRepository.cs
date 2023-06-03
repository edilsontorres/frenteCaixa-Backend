using projetoCaixa.Data;
using projetoCaixa.Entites;
using projetoCaixa.Repositories.Interfaces;

namespace projetoCaixa.Repositories
{
    public class ItemVendaRepository : IVendaItem
    {
        private readonly DataContext _context;
        public ItemVendaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemVenda> AdicionandoProduto(ItemVenda item)
        {
            await _context.AddAsync(item);
            return item; 
        }
    }
}
