using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeCook.Domain;

namespace WeCook.Data.Mappings
{
    public class ReceitaMappings : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(r => r.Ingredientes)
                .IsRequired()
                .HasColumnType("varchar(600)");

            builder.Property(r => r.ModoPreparo)
                .IsRequired()
                .HasColumnType("varchar(600)");

            builder.ToTable("Receita");
        }
    }
}
