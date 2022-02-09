using AspnetCore.DapperVsEFCore.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Mappings
{
    public class LivroMap : DommelEntityMap<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");
            Map(p => p.Id).IsKey();            
        }
    }
}
