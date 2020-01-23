using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Database.Core{
    public interface IRepository<TEntity> where TEntity : class
    {
       Task<IEnumerable<TEntity>> GetAllAsync();
 
    Task<TEntity> GetByIdAsync(int id);
 
    Task<TEntity> CreateAsync(TEntity entity);
 
    Task<int> UpdateAsync(TEntity entity);
 
    Task<int> DeleteAsync(TEntity entity);
      }
}