using projetoCaixa.Models;

namespace projetoCaixa.Entites
{
    public class Venda
    {
        public int Id {get; set;}

        public DateTime DataVenda { get; set;}

        public float ValorTotal { get; set; }

        public bool Status { get; set; }

        public User? user { get; set; }

        public List<ItemVenda>? ItemVenda { get; set; }
        
    }
}
