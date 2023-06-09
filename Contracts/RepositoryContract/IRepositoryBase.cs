﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool tracking);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tracking);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void CreateRange(IEnumerable<T> entities);
        void DeleteAll();
        void DeleteRange(IEnumerable<T> entities);
    }
}
