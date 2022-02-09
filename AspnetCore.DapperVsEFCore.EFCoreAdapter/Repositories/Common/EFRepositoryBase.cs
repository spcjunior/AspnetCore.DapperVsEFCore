using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories.Common;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories.Common
{
    public abstract class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext db;
        protected readonly ILogger<EFRepositoryBase<TEntity>> Logger;

        protected EFRepositoryBase(AppDbContext context, ILogger<EFRepositoryBase<TEntity>> logger)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));            
        }

        public virtual void Insert(ref TEntity obj)
        {
            db.Add(obj);
            db.SaveChanges();
            Logger.LogInformation("Insert  com EFCore");
        }

        public void InsertAll(IEnumerable<TEntity> objs)
        {
            db.AddRange(objs);
            db.SaveChanges();
            Logger.LogInformation("AddAll  com EFCore");
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = db.Set<TEntity>().ToList();
            Logger.LogInformation("GetAll  com EFCore");
            return result;
        }

        public virtual TEntity GetById<TIdentity>(TIdentity id)
        {
            var result = db.Set<TEntity>().Find(id);
            Logger.LogInformation("GetById  com EFCore");
            return result;
        }

        public virtual void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
            Logger.LogInformation("Remove  com EFCore");
        }

        public virtual void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            Logger.LogInformation("Update  com EFCore");
        }

        private bool _disposed = false;

        ~EFRepositoryBase() =>
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
                    db.Dispose();
                }
                _disposed = true;
            }
        }

    
    }
}
