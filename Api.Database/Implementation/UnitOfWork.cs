using System;
using Api.Database.Core;
//using Api.Database.Model;

namespace Api.Database.Implementation{
    // public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class, IDisposable
    // {
    //     //private readonly projectadContext _context;
    //     IRepository<TEntity> _getRepository;     
 
    // public UnitOfWork()
    // {
    //    // _context = context;        
    // }
 
    // // public IRepository<TEntity> GetRepository
    // // {
    // //      //get { return _getRepository ?? (_getRepository = new Repository<TEntity>(_context)); }
    // //     // get { return _repository; }
    // // }

    // public void Save() => _context.SaveChanges();

    // private bool disposed = false;
 
    // protected virtual void Dispose(bool disposing)
    // {
    //     if (!this.disposed)
    //     {
    //         if (disposing)
    //         {
    //             _context.Dispose();
    //         }
    //     }
    //     this.disposed = true;
    // }
 
    // public void Dispose()
    // {
    //     Dispose(true);
    //     System.GC.SuppressFinalize(this);
    // }
    //     // public projectadContext Context { get; }
 
    //     // public UnitOfWork(projectadContext context)
    //     // {
    //     //     Context = context;
    //     // }
    //     // public void Commit() => Context.SaveChanges();

    //     // public void Dispose() => Context.Dispose();
    // }
}