using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public Log Title { get; set; }
        public List<Log> Comments { get; set; }
        public DateTime LatestUpdate { get; set; }
    }
}