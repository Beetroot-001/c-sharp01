using System.Reflection;
using ConsoleApp1;
using Moq;

namespace ConsoleApp1.Tests
{
    [TestClass]
    public class AssemblyServiceTests
    {
        [TestMethod]
        [DataRow ("ConsoleApp1")]
        [DataRow ("ConsoleApp1.Tests")]        
        public void AssemblyServiceTest(string path)
        {
            //arrange           
            //act
            var assemblyService = new AssemblyService(path);            
            //assert
            Assert.IsNotNull(assemblyService);
        }        
    }
}