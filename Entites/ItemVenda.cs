using System.Security.Permissions;

namespace projetoCaixa.Entites
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public List<Product>? Products { get; set; }

        public int IdProduct { get; set; }

        public float ValorUnitario { get; set; }

        public int Quantidade { get; set; }
    }
}
