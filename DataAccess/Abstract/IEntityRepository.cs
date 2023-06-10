using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    /// <summary>
    /// T must be a reference type plus T should be IEntity or an object which is implemented IEntity
    /// class : reference type filter
    /// IEntity: T should be IEntity or an object which is implemented IEntity
    /// new(): should be an object which can be created by "new".
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
