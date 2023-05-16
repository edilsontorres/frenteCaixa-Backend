using projetoCaixa.Models;

namespace projetoCaixa.DTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public float Preco { get; set; }
        public int Estoque { get; set; }
    }
}
