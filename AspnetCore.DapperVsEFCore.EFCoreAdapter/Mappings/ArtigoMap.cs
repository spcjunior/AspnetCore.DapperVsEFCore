using AspnetCore.DapperVsEFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Mappings
{
    public class ArtigoMap : IEntityTypeConfiguration<Artigo>
    {
        public void Configure(EntityTypeBuilder<Artigo> builder)
        {
            builder.ToTable("Artigo");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Artigos)
                .HasForeignKey(p => p.AutorId);
        }
    }
}
