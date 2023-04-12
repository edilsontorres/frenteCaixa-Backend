using projetoCaixa.Models;

namespace projetoCaixa.Service
{
    public interface ITokenService
    {

        Task<string> CreateToken(User user);
    }
}
