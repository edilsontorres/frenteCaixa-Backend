using projetoCaixa.Models;

namespace projetoCaixa.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public float Preco { get; set; }
        public int Estoque { get; set; }
        public User? Users { get; set; }
        public int UserId { get; set; }
       
    }
}
