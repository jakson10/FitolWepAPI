using FitOl.Repository.Abstract;
using FitOl.Repository.Concrete.EntityFrameworkCore.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SportDatabaseContext _context;
        public EfGenericRepository(SportDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<int> Delete(T entity)
        {        
            _context.Set<T>().Remove(entity);
            return await Save();
        }

        public async Task<int> Edit(T entity)
        {
            _context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await Save();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
 
            return _context.Set<T>();
        }

        public IQueryable<T> Include(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetAll();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T> AddEntityAndGetId(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Save()
        {
            int success = await _context.SaveChangesAsync();
            return success;
        }

    }
}
