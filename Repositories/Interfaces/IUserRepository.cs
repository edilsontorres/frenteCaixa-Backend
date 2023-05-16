using projetoCaixa.DTOs;
using projetoCaixa.Models;

namespace projetoCaixa.Repositorie.Iterfaces
{
    public interface IUserRepository
    {
        Task<User> NewUser(User user);

        Task<IEnumerable<UserResponseDTO>> GetUser();

        Task<User> GetUserById(int id);

        Task UpdateUser(User user);

        public void RemoveUser(User user);
        
        Task<bool> SalveAllAsync();
    }
}
