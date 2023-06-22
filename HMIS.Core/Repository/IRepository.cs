using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMIS.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        // Add other methods as needed...
    }

}
