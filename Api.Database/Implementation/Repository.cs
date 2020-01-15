using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Database.Implementation{
    public class Repository<TEntity> :  IRepository<TEntity> where TEntity : class
    {

      readonly projectadContext _context; 
       private DbSet<TEntity> dbSet;       

        public Repository(projectadContext context)
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

        public async Task<int> DeleteAsync(TEntity entity)
        {
          _context.Set<TEntity>().Remove(entity);
            return  await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>  await _context.Set<TEntity>().ToListAsync();       

        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);          
       

        public async Task<int> UpdateAsync(int id, TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await  _context.SaveChangesAsync();
        }
    }
}