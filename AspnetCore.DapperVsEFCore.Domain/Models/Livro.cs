using System.Text.Json.Serialization;

namespace AspnetCore.DapperVsEFCore.Domain.Models
{
    public class Livro
    {
        public int Id { get; set; }       
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }
        public int AutorId{ get; set; }

        [JsonIgnore]
        public virtual Autor Autor { get; set; }
    }
}
