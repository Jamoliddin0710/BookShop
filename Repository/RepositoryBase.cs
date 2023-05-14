using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext context;
        protected DbSet<T> DbSet;
        protected RepositoryBase(RepositoryContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();   
        }

        public virtual void Create(T entity) => DbSet.Add(entity);

        public void CreateRange(IEnumerable<T> entities) => DbSet.AddRange(entities);

        public virtual void  Update(T entity) => DbSet.Update(entity);
    
        public virtual void Delete(T entity) => DbSet.Remove(entity);

        public virtual void DeleteAll() => DbSet.RemoveRange(DbSet);
        public virtual void DeleteRange(IEnumerable<T> entities) => DbSet.RemoveRange(entities);
        public virtual IQueryable<T> FindAll(bool trackChanges) =>
                                 !trackChanges ?
                                 context.Set<T>().AsNoTracking() :
                                 context.Set<T>();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            context.Set<T>().Where(expression).AsNoTracking() :
            context.Set<T>().Where(expression);

    }
}
