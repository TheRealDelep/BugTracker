using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.BLL
{
    public class UserCapabilities : IUserCapabilities
    {
        private IBugTrackerContext context;

        public UserCapabilities()
        {
        }

        public void Register(User user)
        {
        }
    }
}