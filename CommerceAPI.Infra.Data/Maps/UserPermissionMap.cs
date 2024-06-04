using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Infra.Data.Maps;

public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("permissaousuario");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("idpermissaousuario")
            .UseIdentityColumn();

        builder.Property(c => c.PermissionId)
            .HasColumnName("idpermissao");

        builder.Property(x => x.UserId)
            .HasColumnName("idusuario");

        builder.HasOne(x => x.Permission)
            .WithMany(x => x.UserPermissions);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserPermissions);
    }
}