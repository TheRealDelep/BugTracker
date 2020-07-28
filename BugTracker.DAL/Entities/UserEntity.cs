using BugTracker.Cross_Cutting.DAL;
using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using BugTracker.Cross_Cutting.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.DAL.Entities
{
    public class UserEntity : IDBEntity<User>
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public string DBTableName => "users";

        public IDBEntity<User> FromModel(User model)
        {
            Id = model.Id;
            IdentityId = model.IdentityId;
            return this;
        }

        public SQLCommandParameter[] GetParameters()
            => new SQLCommandParameter[]
            {
                //new SQLCommandParameter("id", Id, SqlDbType.Int),
                new SQLCommandParameter("identityId", IdentityId, SqlDbType.Int)
            };

        public IModel ToModel()
        {
            return new User()
            {
                Id = Id,
                IdentityId = IdentityId
            };
        }

        public IDBEntity<User> FromDB(SqlDataReader reader)
        {
            while (reader.Read())
            {
                Id = (int)reader["id"];
                IdentityId = (int)reader["identityId"];
            }
            return this;
        }
    }
}