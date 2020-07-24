using Bugtracker.Services.BugTracker.DAL.Repositories;
using BugTracker.Cross_Cutting.Models;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace BugTracker.DAL.Tests
{
    public class UserRepoTests
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BugTracker.ServiceTests;Integrated Security=True;";
        private UserRepository userRepo;

        [SetUp]
        public void Setup()
        {
            if (userRepo is null) userRepo = new UserRepository(connectionString);

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "initialize";

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        #region GetById

        [Test]
        public void Should_return_IdentityId1_For_UserId1()
        {
            User user = userRepo.GetById(1);
            Assert.AreEqual(1, user.IdentityId);
        }

        [Test]
        public void Should_Throws_ArgumentException_If_Id_Doesnt_exists()
        {
            Assert.Throws<ArgumentException>(() => userRepo.GetById(5));
        }

        [Test]
        public void Should_Throw_ArgumentException_If_Id_Equal_Zero()
        {
            Assert.Throws<ArgumentException>(() => userRepo.GetById(0));
        }

        #endregion GetById

        #region GetAll

        [Test]
        public void GetAll()
        {
        }

        #endregion GetAll

        #region Insert

        [Test]
        public void Should_Throw_Exception_If_User_already_Registered()
        {
            var user = new User() { Id = 1, IdentityId = 1 };
            Assert.Throws<ArgumentException>(() => userRepo.Insert(user));
        }

        [Test]
        public void Should_Throw_Exception_If_IdentityId_Not_Provided()
        {
            var user = new User() { Id = 0, IdentityId = 0 };
            Assert.Throws<ArgumentException>(() => userRepo.Insert(user));
        }

        [Test]
        public void Should_Throw_Exception_If_Identity_Id_Already_Registered()
        {
            var user = new User() { Id = 0, IdentityId = 1 };
            Assert.Throws<ArgumentException>(() => userRepo.Insert(user));
        }

        [Test]
        public void Should_Return_User_With_Id_4()
        {
            var user = new User { IdentityId = 4 };
            Assert.AreEqual(4, userRepo.Insert(user).Id);
        }

        #endregion Insert
    }
}