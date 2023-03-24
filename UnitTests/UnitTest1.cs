using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewTryMVC;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public UserService userService;
        [TestInitialize]
        public void Setup() 
        {
            userService = new UserService();
        }
        [TestMethod]
        public void SumTest()
        {
            int res = userService.sum(3, 5);
            Assert.AreEqual(8, res);
        }
    }
}
