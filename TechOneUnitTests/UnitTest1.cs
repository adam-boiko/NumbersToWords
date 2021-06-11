using NUnit.Framework;
using TechOneAssessment.Controllers;

namespace TechOneUnitTests
{
    public class Tests
    {
        private HomeController TestController { get; set; }
        

        [SetUp]
        public void Setup()
        {
            TestController = new HomeController();
        }

        [Test]
        public void Test1()
        {
            //Act
            var result = TestController.Index();

            Assert.Pass();
        }
    }
}