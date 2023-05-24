using projetoCaixa.Models;

namespace projetoCaixa.Entites
{
    public class Venda
    {
        public int Id { get; set; }

        public double ValorTotal { get; set; }

        public bool Status { get; set; }

        public DateTime DataVenda { get; set; }

        public User? Users { get; set; }

        public ICollection<ItemVenda>? ItemVenda { get; set; }
        
    }
}
