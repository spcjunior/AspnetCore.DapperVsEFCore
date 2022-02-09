using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new ArtigoMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
    }
}
