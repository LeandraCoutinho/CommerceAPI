using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Infra.Data.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("idusuario")
            .UseIdentityColumn();

        builder.Property(c => c.Email)
            .HasColumnName("email");

        builder.Property(c => c.Password)
            .HasColumnName("senha");

        builder.HasMany(x => x.UserPermissions)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
    }
}