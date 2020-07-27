using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Interfaces
{
    public interface IBugTrackerContext
    {
        public IRepository<User> Users { get; set; }
    }
}