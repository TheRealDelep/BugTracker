using Bugtracker.Services.BugTracker.DAL.Repositories;
using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.DAL.Repositories
{
    public class LogRepository : ADORepository<Log>
    {
        public LogRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
        }

        public override bool Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Log GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override Log Insert(Log entity)
        {
            throw new NotImplementedException();
        }

        public override Log Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}