using projetoCaixa.Entites;

namespace projetoCaixa.Repositories.Interfaces
{
    public interface IVendaItem
    {
        public Task<ItemVenda> AdicionandoProduto(ItemVenda item);
    }
}
