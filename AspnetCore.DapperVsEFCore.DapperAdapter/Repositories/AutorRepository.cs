using AspnetCore.DapperVsEFCore.DapperAdapter.Extensions;
using AspnetCore.DapperVsEFCore.DapperAdapter.Repositories.Common;
using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using Dommel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Repositories
{
    public class AutorRepository : DapperRepositoryBase<Autor>, IAutorDapperRepository
    {
        public AutorRepository(SqlConnection sqlConnection, ILogger<DapperRepositoryBase<Autor>> logger) : base(sqlConnection, logger)
        {
        }

        public IEnumerable<Autor> GetByName(string name)
        {
            Logger.LogInformation("Insert  com Dapper");
            return Select(a => a.Nome.Contains(name));
        }

        public Autor GetByIdFetchAll(int? id)
        {
            var resultList = new Dictionary<int, Autor>();
            conn.Get<Autor, Livro, Artigo, Autor>(id, (autor, livro, artigo) =>
            {
                if (!resultList.TryGetValue(autor.Id, out Autor autorEntity))
                {
                    autorEntity = autor;
                    resultList.Add(autorEntity.Id, autorEntity);
                }
                autorEntity.Livros.Add(livro, (x) => x.Id == livro.Id);
                autorEntity.Artigos.Add(artigo, (x) => x.Id == artigo.Id);

                return autor;
            });

            return resultList.Values.FirstOrDefault();
        }

        public override IEnumerable<Autor> GetAll()
        {
            var resultList = new Dictionary<int, Autor>();
            conn.GetAll<Autor, Livro, Artigo, Autor>((autor, livro, artigo) =>
            {
                if (!resultList.TryGetValue(autor.Id, out Autor autorEntity))
                {
                    autorEntity = autor;
                    resultList.Add(autorEntity.Id, autorEntity);
                }
                autorEntity.Livros.Add(livro, (x) => x.Id == livro.Id);
                autorEntity.Artigos.Add(artigo, (x) => x.Id == artigo.Id);

                return autor;
            });

            return resultList.Values;
        }
    }
}
