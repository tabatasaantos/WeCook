using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeCook.Domain;

namespace WeCook.Data.Mappings
{
    public class CategoriaMappings : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nome)
                .IsRequired()
                .HasColumnType("varchar(20)");

            // 1 : N => Categoria : Receitas
            builder.HasMany(c => c.Receitas)
                .WithOne(r => r.Categoria)
                .HasForeignKey(r => r.CategoriaId);

            builder.ToTable("Categoria");
        }
    }
}
