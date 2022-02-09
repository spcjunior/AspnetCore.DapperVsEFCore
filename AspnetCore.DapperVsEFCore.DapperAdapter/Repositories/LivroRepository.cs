using AspnetCore.DapperVsEFCore.DapperAdapter.Repositories.Common;
using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Repositories
{
    public class LivroRepository : DapperRepositoryBase<Livro>, ILivroDapperRepository
    {
        public LivroRepository(SqlConnection sqlConnection, ILogger<DapperRepositoryBase<Livro>> logger) : base(sqlConnection, logger)
        {
        }
    }
}
