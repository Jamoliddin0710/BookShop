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

        protected RepositoryBase(RepositoryContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual void Create(T entity)
        {
            throw new NotImplementedException();
        }


        public virtual void  Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> FindAll(bool tracking) =>
                                 !tracking ?
                                 context.Set<T>().AsNoTracking() :
                                 context.Set<T>();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tracking) =>
            !tracking ?
            context.Set<T>().Where(expression).AsNoTracking() :
            context.Set<T>().Where(expression);
    }
}
