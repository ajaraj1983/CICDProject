using APIProject;


namespace APITestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1==1);

        }

        [Fact]
        public void Test2()
        {
            
            
            Assert.True(VerifyTest.checkTest() == 5);

        }
    }
}