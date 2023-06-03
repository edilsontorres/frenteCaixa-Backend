using projetoCaixa.Entites;

namespace projetoCaixa.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        public Task<Venda> RealizarVenda(Venda venda);

        public void CancelarVenda(int id);
    }
}
