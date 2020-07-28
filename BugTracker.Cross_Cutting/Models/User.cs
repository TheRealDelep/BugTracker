using BugTracker.Cross_Cutting.DAL;
using BugTracker.Cross_Cutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Cross_Cutting.Models
{
    public class User : IModel
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
    }
}