using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewTryMVC;

namespace NewUnit
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
        [DataRow(3, 5, 8)]
        [DataRow(-1, 1, 0)]
        [DataRow(2, 9, 11)]
        [TestMethod]
        public void SumTest(int a, int b, int result)
        {
            int res = userService.sum(a, b);
            Assert.AreEqual(result, res);
        }
    }
}
