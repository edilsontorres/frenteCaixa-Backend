using projetoCaixa.Data;
using projetoCaixa.Models;
using projetoCaixa.Repositorie.Iterfaces;

namespace projetoCaixa.Repositorie
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<User> NewUser(User user)
        {
            _context.Add(user);
            return Task<User>.FromResult(user);
        }
        public async Task<User> GetUser(int Id)
        {
            var users = await _context.Users.FindAsync(Id);
            return users!;
        }
        public Task<string> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SalveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
