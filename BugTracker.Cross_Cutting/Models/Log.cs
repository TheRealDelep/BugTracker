using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Models
{
    public class Log
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}