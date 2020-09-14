using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.EntityFrameworkCore;

namespace Api.Database.Implementation
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        //readonly projectadContext
        readonly bluechub_ProjectADContext _context;
        readonly DbSet<TEntity> dbSet;

        public Repository(bluechub_ProjectADContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<TEntity>().AsNoTracking());
            //return await Task.Run(() => _context.Set<TEntity>());
        }

        public IQueryable<TEntity> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            //return    _context.Set<TEntity>().Where(expression).AsNoTracking();
            return _context.Set<TEntity>().Where(expression);
        }
       
        
        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }   

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}