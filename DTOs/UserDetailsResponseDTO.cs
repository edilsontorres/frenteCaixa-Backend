namespace projetoCaixa.DTOs
{
    public class UserDetailsResponseDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public ICollection<ProductResponseDTO>? Products { get; set; }
    }
}
