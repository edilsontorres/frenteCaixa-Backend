using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data.Configuration;
using projetoCaixa.Entites;
using projetoCaixa.Models;

namespace projetoCaixa.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItemVendas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ItemVendaConfiguration());
        }

    }
}
