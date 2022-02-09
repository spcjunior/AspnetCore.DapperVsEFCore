using AspnetCore.DapperVsEFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.AutorId);
        }
    }
}
