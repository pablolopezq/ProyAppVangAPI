using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProyAppVangAPI.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        T Create(T entity);

        T Update(T entity);
    }
}
