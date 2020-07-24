using BugTracker.Cross_Cutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bugtracker.Services.BugTracker.DAL.Repositories
{
    public abstract class ADORepository<TEntity> : IRepository<TEntity> where TEntity : new()
    {
        protected readonly string connectionString;

        public ADORepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract bool Delete(TEntity entity);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract TEntity GetById(int id);

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Update(TEntity entity);
    }
}