using System.Text.Json.Serialization;

namespace projetoCaixa.Entites
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public float Preco { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade { get; set; }

        [JsonIgnore]
        public Product? Products { get; set; }

        public int ProductId { get; set; }

        public Venda? Vendas { get; set; }

        public int VendaId { get; set; }

    }
}
