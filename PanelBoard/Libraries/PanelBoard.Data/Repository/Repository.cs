using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Data.Repository
{
   
        public abstract class Repository<T>
         : IRepository<T> where T : class
        {
            protected  DbSet<T> _dbSet;
            public Repository(DbContext context)
            {
                _dbSet =  context.Set<T>();
                
            }
            public async Task<EntityEntry> Add(T entity)
            {
                return await _dbSet.AddAsync(entity);
            }

            public void AddRange(IEnumerable<T> entities)
            {
                _dbSet.AddRange(entities);
            }

            public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            {
                if (predicate == null)
                {
                    return _dbSet;
                }
                else
                {
                    return _dbSet.Where(predicate);
                }
            }

            public async Task<IEnumerable<T>> GetAll()
            {
                return await _dbSet.ToListAsync();
            }

            public T GetById(Guid id)
            {
                return _dbSet.Find(id);
            }

            
            public void Remove(T entity)
            {
                _dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entities)
            {
                _dbSet.RemoveRange(entities);
            }
        }
    }

