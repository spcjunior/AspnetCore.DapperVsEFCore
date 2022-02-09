using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories.Common;
using Dommel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Repositories.Common
{
    public abstract class DapperRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlConnection conn;
        protected readonly ILogger<DapperRepositoryBase<TEntity>> Logger;

        protected DapperRepositoryBase(SqlConnection sqlConnection, ILogger<DapperRepositoryBase<TEntity>> logger)
        {
            conn = sqlConnection ?? throw new ArgumentNullException(nameof(sqlConnection));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Insert(ref TEntity obj)
        {
            var id = conn.Insert(obj);

            obj = GetById(id);
            Logger.LogInformation("Insert com Dapper");
        }

        public void InsertAll(IEnumerable<TEntity> objs)
        {
            conn.InsertAll(objs);
            Logger.LogInformation("AddAll com Dapper");
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = conn.GetAll<TEntity>();
            Logger.LogInformation("GetAll com Dapper");
            return result;
        }

        public virtual TEntity GetById<TIdentity>(TIdentity id)
        {
            var result = conn.Get<TEntity>(id);
            Logger.LogInformation("GetById com Dapper");
            return result;
        }

        public virtual void Remove(TEntity obj)
        {
            conn.Delete(obj);
            Logger.LogInformation("Remove com Dapper");
        }

        public virtual void Update(TEntity obj)
        {
            conn.Update(obj);
            Logger.LogInformation("Update com Dapper");
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            var result = conn.Select(predicate);
            Logger.LogInformation("Select com Dapper");
            return result;
        }

        private bool _disposed = false;

        ~DapperRepositoryBase() =>
            Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    conn.Close();
                    conn.Dispose();
                }
                _disposed = true;
            }
        }
 
    }
}
