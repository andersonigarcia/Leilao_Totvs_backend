using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Data.Mappings
{
    public class LeilaoMap : IEntityTypeConfiguration<Leilao>
    {
        public void Configure(EntityTypeBuilder<Leilao> builder)
        {
            builder.ToTable(nameof(Leilao));
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Titulo)
                .HasColumnType("varchar(200)")
                .IsRequired();                        

            builder.HasMany(c => c.Produto)
                .WithOne(c => c.Leilao)
                .HasForeignKey(c => c.LeilaoId)
                .IsRequired();

            builder.HasOne(c => c.Usuario)
               .WithMany(c => c.Leilao)
               .HasForeignKey(c => c.UsuarioId)
               .IsRequired();
        }
    }
}