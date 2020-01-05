using System;
using Api.Database.Model;

namespace Api.Database.Core{
    public interface IUnitOfWork : IDisposable
    {
        projectadContext Context { get;  }
        void Commit();
        ///void Dispose();
    }

}