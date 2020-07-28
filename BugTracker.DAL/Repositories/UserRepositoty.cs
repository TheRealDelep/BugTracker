using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using BugTracker.DAL.Entities;

namespace Bugtracker.Services.BugTracker.DAL.Repositories
{
    public class UserRepository : ADORepository<UserEntity, User>
    {
        public UserRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
        }

        public override User Insert(User model)
        {
            if (model.IdentityId == 0) throw new ArgumentException("IdentityId cannot be equal to 0");

            try
            {
                return base.Insert(model);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw new ArgumentException($"An IdentityUser with Id: {model.IdentityId} is already registered in the database ");
            }
        }
    }
}