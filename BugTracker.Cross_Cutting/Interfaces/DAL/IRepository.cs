using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Interfaces
{
    public interface IRepository<TEntity> where TEntity : new()
    {
        public TEntity GetById(int id);

        public IEnumerable<TEntity> GetAll();

        public TEntity Insert(TEntity entity);

        public TEntity Update(TEntity entity);

        public bool Delete(TEntity entity);
    }
}