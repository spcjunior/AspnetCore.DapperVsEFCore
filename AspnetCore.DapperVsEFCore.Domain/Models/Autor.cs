using System.Collections.Generic;

namespace AspnetCore.DapperVsEFCore.Domain.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Pais { get; set; }
        public virtual List<Livro> Livros { get; set; } = new List<Livro>();
        public virtual List<Artigo> Artigos { get; set; } = new List<Artigo>();
    }
}
