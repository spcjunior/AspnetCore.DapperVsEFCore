using AspnetCore.DapperVsEFCore.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Mappings
{
    public class AutorMap : DommelEntityMap<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");            
            Map(p => p.Id).IsKey();         
        }
    }
}
