namespace projetoCaixa.Entites
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public double ValorUnitario { get; set; }

        public int Quantidade { get; set; }

        public Product? Products { get; set; }

        public int ProductId { get; set; }
    }
}
