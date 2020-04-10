using System;
// using Api.Database.Model;

namespace Api.Database.Core
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        IRepository<TEntity> GetRepository { get; }
        void Save();
        //void Commit();
        ///void Dispose();
    }

}