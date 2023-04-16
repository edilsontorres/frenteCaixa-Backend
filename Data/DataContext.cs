using Microsoft.EntityFrameworkCore;
using projetoCaixa.Models;

namespace projetoCaixa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
