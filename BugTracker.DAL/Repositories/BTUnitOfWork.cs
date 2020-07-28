using Bugtracker.Services.BugTracker.DAL.Repositories;
using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.DAL.Repositories
{
    public class BTUnitOfWork : IBTUnitOfWork, IDisposable
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;
        public IRepository<User> Users { get; set; }

        private bool Disposed { get; set; } = false;

        public BTUnitOfWork(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();

            Users = new UserRepository(connection, transaction);
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Save(string savePointName)
        {
            transaction.Save(savePointName);
        }

        public void RollBack(string savePointName = null)
        {
            transaction.Rollback(savePointName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;

                if (disposing)
                {
                }

                connection.Close();
            }
        }

        ~BTUnitOfWork()
        {
            Dispose(false);
        }
    }
}