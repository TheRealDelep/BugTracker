using BugTracker.Cross_Cutting.DAL;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Interfaces
{
    public interface IRepository<TModel>
        where TModel : IModel
    {
        public TModel GetById(int id);

        public IEnumerable<TModel> GetAll();

        public TModel Insert(TModel model);

        public TModel Update(TModel model);

        public bool Delete(TModel model);
    }
}