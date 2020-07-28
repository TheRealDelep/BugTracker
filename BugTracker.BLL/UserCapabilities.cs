using BugTracker.Cross_Cutting.Interfaces;
using BugTracker.Cross_Cutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.BLL
{
    public class UserCapabilities : IUserCapabilities
    {
        private IBTUnitOfWork context;

        public UserCapabilities(IBTUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        public User Register(User user)
        {
            using (context)
            {
                var added = context.Users.Insert(user);
                context.Commit();
                return added;
            }
        }
    }
}