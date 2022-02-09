using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Context;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories
{
    public class AutorRepository : EFRepositoryBase<Autor>, IAutorEFCoreRepository
    {
        public AutorRepository(AppDbContext context, ILogger<EFRepositoryBase<Autor>> logger) : base(context, logger)
        {
        }

        public Autor GetByIdFetchLivro(int? id)
        {
            var result = db.Autores                
                .Include(x => x.Livros)
                .FirstOrDefault(a => a.Id == id);
            Logger.LogInformation("GetAll  com EFCore");
            return result;
        }

        public IEnumerable<Autor> GetByName(string name)
        {
            var result = db.Autores               
               .Where(a => a.Nome.Contains(name));
            Logger.LogInformation("GetAll  com EFCore");
            return result;
        }

        public override IEnumerable<Autor> GetAll()
        {
            return db.Autores
                .Include(a => a.Livros)
                .Include(a => a.Artigos)
                .ToList();
        }

    }
}
