using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet7.Domain.Entities;

namespace MP.ApiDotNet7.Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // mapeando as configurações do banco
        builder.ToTable("produto");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idproduto")
            .UseIdentityColumn();

        builder.Property(x => x.CodErp)
            .HasColumnName("coderp");

        builder.Property(x => x.Name)
            .HasColumnName("nome");

        builder.Property(x => x.Price)
            .HasColumnName("preco");

        builder.HasMany(x => x.Purchases)
            .WithOne(P => P.Product)
            .HasForeignKey(x => x.ProductId);
    }
}