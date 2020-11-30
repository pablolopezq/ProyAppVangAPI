using ProyAppVangAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ProyAppVangAPI.Core.Interfaces;

namespace ProyAppVangAPI.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ProyAppVangAPIDbContext _proyAppDbContext;

        public EntityFrameworkRepository(ProyAppVangAPIDbContext shopOnlineDbContext)
        {
            _proyAppDbContext = shopOnlineDbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _proyAppDbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _proyAppDbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _proyAppDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Update(T t)
        {
            T updated = _proyAppDbContext.Update(t).Entity;
            _proyAppDbContext.SaveChanges();
            return updated;
        }

        public T Create(T t)
        {
            _proyAppDbContext.Add<T>(t);
            _proyAppDbContext.SaveChanges();
            return t;
        }
    }
}
