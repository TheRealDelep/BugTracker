using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Bugtracker.Services.BugTracker.DAL.Repositories
{
    public class UserRepository : ADORepository<User>
    {
        public UserRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
        }

        public override bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public override User GetById(int id)
        {
            if (id == 0) throw new ArgumentException("Id can not be equal to zero");

            User result = new User();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"Select * From users where id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Transaction = transaction;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Id = (int)reader["id"];
                        result.IdentityId = (int)reader["id"];
                    }
                }
            }
            if (result.Id == 0) throw new ArgumentException($"There is no user at Id {id}");

            return result;
        }

        public override User Insert(User entity)
        {
            if (entity.Id != 0) throw new ArgumentException("Cannot insert user with Id different than 0");
            if (entity.IdentityId == 0) throw new ArgumentException("IdentityId cannot be equal to 0");

            User result = new User();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @$"Insert Into users (identityId) Values(@identityId);
                                            Select * From users where identityId = @identityId";

                command.Parameters.Add("@identityId", SqlDbType.Int).Value = entity.IdentityId;
                command.Transaction = transaction;
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = (int)reader["id"];
                            result.IdentityId = (int)reader["identityId"];
                        }
                    }
                }
                catch (SqlException)
                {
                    throw new ArgumentException($"There is already a user linked to the Identity at Id {entity.IdentityId}");
                }
            }
            return result;
        }

        public override User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}