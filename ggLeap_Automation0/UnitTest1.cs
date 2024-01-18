using NUnit.Framework;

namespace ggLeap_Automation0
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            System.Console.WriteLine("code change test");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}