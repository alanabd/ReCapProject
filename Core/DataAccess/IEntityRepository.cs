using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;


namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
