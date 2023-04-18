using projetoCaixa.Models;

namespace projetoCaixa.Repositorie.Iterfaces
{
    public interface IUserRepository
    {
        Task<User> NewUser(User user);

        Task<User> GetUser(int Id);

        Task<string> UpdateUser(User user);

        Task<string> RemoveUser(int Id);
        
        Task<bool> SalveAllAsync();
    }
}
