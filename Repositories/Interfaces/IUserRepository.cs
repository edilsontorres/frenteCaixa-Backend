using projetoCaixa.Models;

namespace projetoCaixa.Repositorie.Iterfaces
{
    public interface IUserRepository
    {
        void NewUser(User user);
        Task<string> UpdateUser(User user);
        Task<string> RemoveUser(int Id); 
        Task<bool> SalveAllAsync();
    }
}
