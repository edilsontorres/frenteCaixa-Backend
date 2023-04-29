using projetoCaixa.Migrations;

namespace projetoCaixa.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string? Descriao { get; set; }
        public float Preco { get; set; }
        public int Estoque { get; set; }
        public int UserId { get; set; }
        //public User? Users { get; set; }
    }
}
