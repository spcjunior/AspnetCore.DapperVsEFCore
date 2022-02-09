using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Context;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories.Common;
using Microsoft.Extensions.Logging;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories
{
    public class LivroRepository : EFRepositoryBase<Livro>, ILivroEFCoreRepository
    {
        public LivroRepository(AppDbContext context, ILogger<EFRepositoryBase<Livro>> logger) : base(context, logger)
        {
        }
    }
}
