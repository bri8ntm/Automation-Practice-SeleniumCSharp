using NUnit.Framework;

namespace ggLeap_Automation0
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            System.Console.WriteLine("code change test");
            System.Console.WriteLine("code change test 0");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}