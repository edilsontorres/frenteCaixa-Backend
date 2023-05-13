using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> NewUser(User user)
        {
            await _context.AddAsync(user);
            return user;
        }
        public async Task<User> GetUser(int id)
        {
            var users = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return users!;
        }
        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void RemoveUser(User user)
        {
           _context.Remove(user);
        }

        public async Task<bool> SalveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
