using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoAPI.Models;

namespace ProdutoAPI.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired().HasMaxLength(255);  
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.ProdutoId);

            builder.HasOne(x => x.Pruduto);
        }
    }
}
