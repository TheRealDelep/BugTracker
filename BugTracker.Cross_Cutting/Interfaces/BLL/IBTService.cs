using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Interfaces
{
    public interface IBTService
    {
        public IUserCapabilities User { get; set; }
    }
}