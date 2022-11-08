using System.Collections;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public bool Push_TestElement_true()
        {
            // arrange
            ConsoleApp1.Stack<Object> stack = new ConsoleApp1.Stack<Object>();
            int testlenth = stack.Lenth;
            Element<string> element = new Element<string> { Data = "Test element" };
            //act
            stack.Push(element);
            //assert
            
            return stack.Lenth>testlenth;
        }
    }
}