using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.Cross_Cutting.DAL
{
    public interface IDBEntity<TModel> where TModel : IModel
    {
        public int Id { get; set; }
        public string DBTableName { get; }

        public IModel ToModel();

        public IDBEntity<TModel> FromModel(TModel model);

        public IDBEntity<TModel> FromDB(SqlDataReader reader);

        public SQLCommandParameter[] GetParameters();
    }
}