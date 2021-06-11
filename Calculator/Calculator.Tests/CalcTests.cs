using Microsoft.QualityTools.Testing.Fakes;
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


        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            using (var context = ShimsContext.Create())
            {

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 7);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 8);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 9);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 10);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 11);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 12);
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 13);
                Assert.IsTrue(calc.IsWeekend());
            }
        }


    }
}
