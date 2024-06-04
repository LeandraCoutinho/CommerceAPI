using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Infra.Data.Maps;

public class PermissionMap : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idpermissao")
            .UseIdentityColumn();

        builder.Property(x => x.VisualName)
            .HasColumnName("nomevisual");

        builder.Property(x => x.PermissionName)
            .HasColumnName("nomepermissao");

        builder.HasMany(x => x.UserPermissions)
            .WithOne(p => p.Permission)
            .HasForeignKey(p => p.PermissionId);
    }
}