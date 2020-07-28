using BugTracker.Cross_Cutting.DAL;
using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using BugTracker.Cross_Cutting.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Bugtracker.Services.BugTracker.DAL.Repositories
{
    public abstract class ADORepository<TEntity, TModel> : IRepository<TModel>
        where TEntity : IDBEntity<TModel>, new()
        where TModel : IModel, new()
    {
        protected readonly SqlConnection connection;
        protected readonly SqlTransaction transaction;

        public ADORepository(SqlConnection connection, SqlTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public bool Delete(TModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel GetById(int id)
        {
            if (id == 0) throw new ArgumentException("Id can not be equal to zero");
            var entity = new TEntity();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @$"Select * From {entity.DBTableName} where id = @Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                command.Transaction = transaction;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    entity.FromDB(reader);
                    if (entity.Id == 0) throw new ArgumentException($"There are no element in the table {entity.DBTableName} at id: {id}");
                }
            }
            return (TModel)entity.ToModel();
        }

        public virtual TModel Insert(TModel model)
        {
            if (model.Id != 0) throw new ArgumentException("Cannot insert entity with Id different than 0");

            var entity = new TEntity().FromModel(model);
            int entityId = 0;

            using (SqlCommand command = connection.CreateCommand())
            {
                SQLCommandParameter[] parameters = entity.GetParameters();

                string columns = parameters.Aggregate("",
                    (result, next) => next.Name == parameters.Last().Name ?
                    result += next.Name : result += $"{next.Name}, ");

                string values = parameters.Aggregate("",
                    (result, next) => next.Name == parameters.Last().Name ?
                    result += $"@{next.Name }" : result += $"@{next.Name}, ");

                command.CommandText = @$"Insert Into {entity.DBTableName} ({columns}) Values({values}); Select Scope_Identity();";

                Array.ForEach(parameters, p => command.AddParameter(p));
                command.Transaction = transaction;
                entityId = Convert.ToInt32(command.ExecuteScalar());
            }
            return GetById(entityId);
        }

        public TModel Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}