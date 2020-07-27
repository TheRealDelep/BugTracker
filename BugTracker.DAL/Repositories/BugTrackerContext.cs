using Bugtracker.Services.BugTracker.DAL.Repositories;
using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.DAL.Repositories
{
    public class BugTrackerContext : IBugTrackerContext, IDisposable
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;
        public IRepository<User> Users { get; set; }

        public BugTrackerContext(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            transaction = connection.BeginTransaction();
            connection.Open();

            Users = new UserRepository(connection, transaction);
        }

        public void Save()
        {
            transaction.Commit();
        }

        public void Dispose()
        {
            transaction.Rollback();
            connection.Close();
        }

        ~BugTrackerContext()
        {
            Dispose();
        }
    }
}