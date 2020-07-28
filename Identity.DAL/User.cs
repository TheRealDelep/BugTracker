using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Services.Identity.DAL
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string UserName => $"{FirstName} {LastName}";

        public UserRole Role { get; set; }

        public User() : base()
        {
        }
    }
}