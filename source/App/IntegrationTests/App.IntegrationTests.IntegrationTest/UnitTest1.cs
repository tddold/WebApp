using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data;

namespace App.IntegrationTests.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            AppDbContext context = new AppDbContext();

            // At
            int usersCount = context.Users.Count();

            // Assert
            Assert.AreEqual(6, usersCount);
        }
    }
}
