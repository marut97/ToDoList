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
            var username = "testUsername";
            var password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUsername1";
            password = "test123456789";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUsername2";
            password = "test123456789!@#$%&*<>?";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));

            username = "testUsername3";
            password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));
        }

        [TestMethod]
        public void InvalidRegister()
        {
            var username = "testUsername";
            var password = "testPassword";
            Assert.IsTrue(m_authenticationRepository.RegisterUser(username, password));
            password = "anotherPW";
            Assert.IsFalse(m_authenticationRepository.RegisterUser(username, password));
            
            password = "testPassword";
            Assert.IsFalse(m_authenticationRepository.RegisterUser(username, password));
        }

        [TestMethod]
        public void ValidLogin()
        {
            ValidRegister();

            Assert.IsTrue(m_authenticationRepository.Login("testUsername", "testPassword")>0);
            Assert.IsTrue(m_authenticationRepository.Login("testUsername3", "testPassword")>0);
        }

        [TestMethod]
        public void InvalidLogin()
        {
            ValidRegister();

            Assert.IsFalse(m_authenticationRepository.Login("testUsername", "")>0);
            Assert.IsFalse(m_authenticationRepository.Login("testUsername", "TestPassword")>0);
            Assert.IsFalse(m_authenticationRepository.Login("TestUsername", "testPassword")>0);
            Assert.IsFalse(m_authenticationRepository.Login("", "testPassword")>0);
            Assert.IsFalse(m_authenticationRepository.Login("*", "testPassword")>0);
            Assert.IsFalse(m_authenticationRepository.Login("testUserNam?", "testPassword")>0);
        }

        [TestMethod]
        public void ValidDelete()
        {
            ValidRegister();

            Assert.IsTrue(m_authenticationRepository.DeleteUser("testUsername", "testPassword"));
            Assert.IsTrue(m_authenticationRepository.DeleteUser("testUsername1", "test123456789"));
            Assert.IsTrue(m_authenticationRepository.DeleteUser("testUsername2", "test123456789!@#$%&*<>?"));
            Assert.IsTrue(m_authenticationRepository.DeleteUser("testUsername3", "testPassword"));
        }

        [TestMethod]
        public void InvalidDelete()
        {
            ValidRegister();

            Assert.IsFalse(m_authenticationRepository.DeleteUser("testUsername", "*"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("testUsername1", "test1234567890"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("testUsername2", "test123456789!@#$%&*<>??"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("testUsername3", "testPasswor?"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("testUserNam?", "testPassword"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("*", "testPassword"));
            Assert.IsFalse(m_authenticationRepository.DeleteUser("", "testPassword"));
        }

        [TestMethod]
        public void ValidUpdateUsername()
        {
            ValidRegister();

            Assert.IsTrue(m_authenticationRepository.UpdateUsername("testUsername", "testPassword", "newTestUsername"));
            Assert.IsTrue(m_authenticationRepository.Login("newTestUsername", "testPassword")>0);
            Assert.IsTrue(m_authenticationRepository.UpdateUsername("testUsername1", "test123456789", "newTestUsername1"));
            Assert.IsTrue(m_authenticationRepository.Login("newTestUsername1", "test123456789")>0);
            Assert.IsTrue(m_authenticationRepository.UpdateUsername("testUsername2", "test123456789!@#$%&*<>?", "newTestUsername2"));
            Assert.IsTrue(m_authenticationRepository.Login("newTestUsername2", "test123456789!@#$%&*<>?")>0);
            Assert.IsTrue(m_authenticationRepository.UpdateUsername("testUsername3", "testPassword", "newTestUsername3"));
            Assert.IsTrue(m_authenticationRepository.Login("newTestUsername3", "testPassword")>0);
        }

        [TestMethod]
        public void InvalidUpdateUsername()
        {
            ValidRegister();

            Assert.IsFalse(m_authenticationRepository.UpdateUsername("testUsername?", "testPasswor?", "newTestUsername"));
            Assert.IsFalse(m_authenticationRepository.Login("newTestUsername", "testPassword")>0);

            Assert.IsFalse(m_authenticationRepository.UpdateUsername("testUsername?", "", "newTestUsername"));
            Assert.IsFalse(m_authenticationRepository.Login("newTestUsername", "testPassword")>0);

            Assert.IsFalse(m_authenticationRepository.UpdateUsername("", "testPassword", "newTestUsername"));
            Assert.IsFalse(m_authenticationRepository.Login("newTestUsername", "testPassword")>0);
        }

        [TestMethod]
        public void ValidUpdatePassword()
        {
            ValidRegister();

            Assert.IsTrue(m_authenticationRepository.UpdatePassword("testUsername", "testPassword", "newTestPassword"));
            Assert.IsTrue(m_authenticationRepository.Login("testUsername", "newTestPassword")>0);

            Assert.IsTrue(m_authenticationRepository.UpdatePassword("testUsername1", "test123456789", "newTestPassword1234!@#$"));
            Assert.IsTrue(m_authenticationRepository.Login("testUsername1", "newTestPassword1234!@#$")>0);

            Assert.IsTrue(m_authenticationRepository.UpdatePassword("testUsername2", "test123456789!@#$%&*<>?", "newTestPassword!@#"));
            Assert.IsTrue(m_authenticationRepository.Login("testUsername2", "newTestPassword!@#")>0);

            Assert.IsTrue(m_authenticationRepository.UpdatePassword("testUsername3", "testPassword", "newTestPassword1234"));
            Assert.IsTrue(m_authenticationRepository.Login("testUsername3", "newTestPassword1234")>0);
        }

        [TestMethod]
        public void InvalidUpdatePassword()
        {
            ValidRegister();

            Assert.IsFalse(m_authenticationRepository.UpdatePassword("testUsername?", "testPasswor?", "newTestPassword"));
            Assert.IsFalse(m_authenticationRepository.Login("testUsername", "newTestPassword")>0);

            Assert.IsFalse(m_authenticationRepository.UpdatePassword("testUsername?", "", "newTestUsername"));
            Assert.IsFalse(m_authenticationRepository.Login("testUsername", "newTestPassword")>0);

            Assert.IsFalse(m_authenticationRepository.UpdatePassword("", "testPassword", "newTestUsername"));
            Assert.IsFalse(m_authenticationRepository.Login("testUsername", "newTestPassword")>0);
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
