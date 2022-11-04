using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        [DataRow("", 0)]

        [DataRow("1,", 1)]
        [DataRow("1,1", 2)]
        [DataRow("1,2", 3)]
        [DataRow("1,2,3,4,5", 15)]
        [DataRow("1,2,3,4,5,6", 21)]

        [DataRow("1\n2,3", 6)]
        [DataRow("1\n2\n,3", 6)]
        [DataRow("1,\n", 1)]

        [DataRow("//;\n1;2", 3)]
        [DataRow("//@\n1@2@3", 6)]


        [DataRow("1001,2", 2)]
        [DataRow("1001,2000", 0)]

        [DataRow("//[***]\n1***2***3", 6)]
        [DataRow("//[***][,]\n1***2***3,4", 10)]
        public void AreEqual(string input, int expectedResult)
        {
            //arrange

            //act
            var calcService = new CalcService();
            int sum = calcService.Add(input);

            //assert
            Assert.AreEqual(expectedResult, sum);
        }

        [TestMethod]
        [DataRow("//,\n1,2,-3")]
        [ExpectedException(typeof(ArgumentException))] // Exception
        public void isException(string input)
        {
            //arrange

            //act
            var calcService = new CalcService();
            calcService.Add(input);

            //assert
        }

        [TestMethod]

        [DataRow("//[***][,]\n1***2***3,4", 10)]
        public void AreEqual2(string input, int expectedResult)
        {
            //arrange

            //act
            var calcService = new CalcService();
            int sum = calcService.Add2(input);

            //assert
            Assert.AreEqual(expectedResult, sum);
        }


    }
}