using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoListService.Lib.AuthenticationRepository;
using System.Data.SQLite;

namespace ToDoListService.Test.Unit.AuthenticationRepositoryTest
{
    [TestClass]
    public class AuthenticationRepositoryTest
    {
        private AuthenticationRepository m_authenticationRepository;
        [TestInitialize]
        public void Setup()
        {
            m_authenticationRepository = new AuthenticationRepository(true);
        }

        [TestMethod]
        public void ValidRegister()
        {
            var username = "testUserName";
            var password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUsername1";
            password = "test123456789";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUsername2";
            password = "test123456789!@#$%&*<>?";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUserName3";
            password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));
        }

        [TestMethod]
        public void InvalidRegister()
        {
            var username = "testUserName";
            var password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));
            password = "anotherPW";
            Assert.IsFalse(m_authenticationRepository.RegisterUser(username, password));
            
            password = "testPassword";
            Assert.IsFalse(m_authenticationRepository.RegisterUser(username, password));
        }

        [TestCleanup]
        public void Teardown()
        {
            var connectionString = "Data Source=C:\\ToDoListDatabase\\Test\\ToDoListDatabase.sqlite;Version=3;";
            using (var databaseConnection = new SQLiteConnection(connectionString))
            {
                databaseConnection.Open();
                using (var cmd = new SQLiteCommand(databaseConnection))
                {
                    cmd.CommandText = "DELETE FROM ToDoListAuthentication;";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
