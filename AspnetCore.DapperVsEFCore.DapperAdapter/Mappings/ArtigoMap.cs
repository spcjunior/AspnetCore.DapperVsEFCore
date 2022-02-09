using AspnetCore.DapperVsEFCore.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Mappings
{
    public class ArtigoMap : DommelEntityMap<Artigo>
    {
        public ArtigoMap()
        {
            ToTable("Artigo");
            Map(p => p.Id).IsKey();
        }
    }
}
