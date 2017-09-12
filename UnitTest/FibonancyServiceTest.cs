using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Models;

namespace UnitTest
{
    [TestClass]
    public class FibonancyServiceTest
    {
        [DataTestMethod]
        [DataRow(0, -1)]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(3, 2)]
        [DataRow(4, 3)]
        [DataRow(5, 5)]
        [DataRow(6, 8)]
        [DataRow(7, 13)]
        [DataRow(101, -1)]
        [DataRow(102, -1)]
        public void GivenNumber_WhenCalculateFibonanci_ThenBeOk(int n, double result)
        {
            //Given

            //When
            Logger.Info($"Test FibonanciService with n = {n} and result = {result}");
            var fib = FibonanciService.CalculateFibonanci(n);
            //Then
            Assert.AreEqual(fib, result);
        }
    }
}
