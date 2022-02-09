using System;
using System.Collections.Generic;

namespace AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories.Common
{  
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Insert(ref TEntity obj);
        void InsertAll(IEnumerable<TEntity> objs);
        TEntity GetById<TIdentity>(TIdentity id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
