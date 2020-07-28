using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Interfaces
{
    public interface IBTUnitOfWork : IDisposable
    {
        public IRepository<User> Users { get; set; }

        public void Save(string savePointName);

        public void Commit();

        public void RollBack(string savePointName = null);
    }
}