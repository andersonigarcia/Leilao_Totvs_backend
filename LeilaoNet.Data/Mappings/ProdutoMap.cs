using LeilaoNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeilaoNet.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));
            builder.HasKey(c => c.Id);
            builder.Ignore(c => c.CascadeMode);

            builder.HasOne(c => c.Leilao)
                .WithMany(c => c.Produto)
                .HasForeignKey(c => c.LeilaoId)
                .IsRequired();            
        }
    }
}
