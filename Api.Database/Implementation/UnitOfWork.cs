using System;
using Api.Database.Core;
using Api.Database.Model;

namespace Api.Database.Implementation{
    public class UnitOfWork :  IUnitOfWork
    {
        public projectadContext Context { get; }
 
        public UnitOfWork(projectadContext context)
        {
            Context = context;
        }
        public void Commit() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}