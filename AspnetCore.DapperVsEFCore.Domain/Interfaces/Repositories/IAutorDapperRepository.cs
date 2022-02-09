using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories.Common;
using AspnetCore.DapperVsEFCore.Domain.Models;
using System.Collections.Generic;

namespace AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories
{
    public interface IAutorDapperRepository : IRepositoryBase<Autor> 
    {
        IEnumerable<Autor> GetByName(string name);

        Autor GetByIdFetchAll(int? id);
    }
}
