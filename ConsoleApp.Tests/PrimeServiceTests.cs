using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConsoleApp.Tests
{
	[TestClass]
	public class PrimeServiceTests
	{
		[TestMethod]
		[DataRow(1, false)]
		[DataRow(2, true)]
		public void IsPrime_Input1_ReturnsFalse(int number, bool expectedResult)
		{
			// act
			//var primeService = new PrimeService();
			//bool isPrime = primeService.IsPrime(number);

			// assert
			//Assert.AreEqual(expectedResult, isPrime);
		}
	}
}