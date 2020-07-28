using BugTracker.DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.DAL.Tests
{
    public class UnitOfWorkTests
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BugTracker.ServiceTests;Integrated Security=True;";

        [Test]
        public void Should_Throw_Exception_If_Not_Used_In_Using_Block()
        {
            {
                var uow = new BTUnitOfWork(connectionString);
            }
        }
    }
}