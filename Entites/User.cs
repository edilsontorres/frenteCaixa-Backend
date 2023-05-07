using projetoCaixa.Entites;

namespace projetoCaixa.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
