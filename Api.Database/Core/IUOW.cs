using Microsoft.EntityFrameworkCore;
using System;
namespace Api.Database.Core
{
     public interface IUOW : IDisposable
    {
        IRepo<TEntity> GetRepository<TEntity>() where TEntity : class;
        
        int Commit();
    }

    public interface IUOfW<TContext> : IUOW where TContext : DbContext
    {
        TContext Context { get; }
    }
    
}