using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories.Common;
using AspnetCore.DapperVsEFCore.Domain.Models;
using System.Collections.Generic;

namespace AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories
{
    public interface IAutorEFCoreRepository : IRepositoryBase<Autor>
    {
        IEnumerable<Autor> GetByName(string name);

        Autor GetByIdFetchLivro(int? id);
    }
}
