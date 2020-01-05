using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Database.Core{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        IEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);
      }
}