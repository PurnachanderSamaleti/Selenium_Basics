namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is the Test1");
        }


        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is the Test2");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Teardown method");
        }
    }
}
