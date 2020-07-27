using BugTracker.Cross_Cutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.BLL
{
    public class BTService : IBTService
    {
        private readonly IBugTrackerContext context;
        public IUserCapabilities User { get; set; }

        public BTService(IBugTrackerContext context)
        {
            this.context = context;
            User = new UserCapabilities();
        }
    }
}