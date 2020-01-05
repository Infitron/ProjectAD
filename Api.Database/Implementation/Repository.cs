using System;
using System.Collections.Generic;
using Api.Database.Core;

namespace Api.Database.Implementation{
    public class Repository<T> : IRepository<T> where T : class
    {
       private readonly IUnitOfWork _unitOfWork;
        
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddAsync(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }
 
        public void DeleteAsync(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }
 
        public IEnumerable<T> GetAllAsync()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }
 
        public IEnumerable<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
 
        public void UpdateAsync(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }
    }
}