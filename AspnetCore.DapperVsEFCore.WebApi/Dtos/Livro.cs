using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreApi.DapperVsEFCore.WebApi.Dtos
{
    public record LivroPost(string Titulo, int AnoPublicacao, int AutorId);
}
