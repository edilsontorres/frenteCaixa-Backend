using projetoCaixa.Models;

namespace projetoCaixa.Service.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
