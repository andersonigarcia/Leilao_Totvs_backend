using LeilaoNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeilaoNet.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            builder.HasKey(c => c.Id);
            builder.Ignore(c => c.CascadeMode);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(400)")
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.HasMany(c => c.Leilao)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId)
                .IsRequired();
        }
    }
}
