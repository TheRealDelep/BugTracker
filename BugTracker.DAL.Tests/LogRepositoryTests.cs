using BugTracker.Cross_Cutting.Models;
using BugTracker.DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.DAL.Tests
{
    public class LogRepositoryTests
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BugTracker.ServiceTests;Integrated Security=True;";
        private SqlConnection connection;
        private SqlTransaction transaction;
        private LogRepository logRepo;

        //[SetUp]
        //public void Setup()
        //{
        //    connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    transaction = connection.BeginTransaction("transaction");
        //    logRepo = new LogRepository(connection, transaction);
        //}

        //[TearDown]
        //public void CleanUp()
        //{
        //    transaction.Commit();
        //    connection.Close();
        //}

        //#region GetById

        //[Test]
        //public void Should_Return_TestLog_At_Id_1()
        //{
        //    var testLog = new Log()
        //    {
        //        Id = 1,
        //        Author = new User()
        //        {
        //            Id = 1,
        //            IdentityId = 1
        //        },
        //        Title = "Test",
        //        Body = "Hi, I am testing my repo",
        //        Date = new DateTime(),
        //    };

        //    var dbLog = logRepo.GetById(testLog.Id);

        //    Assert.AreEqual(testLog.Author.Id, dbLog.Author.Id);
        //    Assert.AreEqual(testLog.Title, dbLog.Title);
        //    Assert.AreEqual(testLog.Body, dbLog.Body);
        //    Assert.AreEqual(testLog.Date, dbLog.Date);
        //}

        //#endregion GetById
    }
}