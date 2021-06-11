using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_2_and_5_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 5);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 0, 1)]
        [DataRow(0, 1, 1)]
        [DataRow(2, 4, 6)]
        [DataRow(-1, 0, -1)]
        [DataRow(0, -1, -1)]
        [DataRow(-1, -1, -2)]
        [DataRow(-1, 2, 1)]
        public void Calc_Sum(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() =>
                                    calc.Sum(int.MaxValue, 1));

        }

    }
}
