using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetoCaixa.Entites;

namespace projetoCaixa.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Users).WithMany(x => x.Products).HasForeignKey(x => x.UserId);
        }
    }
}
