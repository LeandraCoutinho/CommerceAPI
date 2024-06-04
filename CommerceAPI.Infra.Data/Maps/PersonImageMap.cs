using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Infra.Data.Maps;

public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
{
    public void Configure(EntityTypeBuilder<PersonImage> builder)
    {
        builder.ToTable("pessoaimagem");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idimagem")
            .UseIdentityColumn();

        builder.Property(x => x.PersonId)
            .HasColumnName("idpessoa");

        builder.Property(x => x.ImageBase)
            .HasColumnName("imagembase");

        builder.Property(x => x.ImageUrl)
            .HasColumnName("imagemurl");

        builder.HasOne(x => x.Person)
            .WithMany(x => x.PersonImages);
    }
}