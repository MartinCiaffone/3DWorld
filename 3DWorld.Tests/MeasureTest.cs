using Space3DWorld.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Space3DWorld.Globals;  //C# V6

namespace Space3DWorld.Tests
{
    [TestClass]
    public class MeasureTest
    {

        private static readonly IUnitLookup UnitLookup =
            new UnitLookup();

        [TestMethod]
        public void Two_of_same_amount_and_same_units_should_be_equal()
        {
            var firstMeasure = Measure.FromDecimal(5, pixel, UnitLookup,1);
            var secondMeasure = Measure.FromDecimal(5, pixel, UnitLookup,1);

            Assert.IsTrue(firstMeasure.Equals(secondMeasure));
        }

        [TestMethod]
        public void Two_of_same_amount_but_different_units_should_be_equal()
        {
            var firstMeasure = Measure.FromDecimal(5, pixel, UnitLookup,1);
            var secondMeasure = Measure.FromDecimal(5, millimeter, UnitLookup,1);

            Assert.IsTrue(!firstMeasure.Equals(secondMeasure));
        }

        [TestMethod]
        public void FromString_and_FromDecimal_should_be_equal()
        {
            var firstMeasure = Measure.FromDecimal(5, millimeter, UnitLookup,1);
            var secondMeasure = Measure.FromString("5,0", millimeter, UnitLookup,1); //NOTE use the decimal separator that match your localization.

            Assert.IsTrue(firstMeasure.Equals(secondMeasure));
        }

        [TestMethod]
        public void Unused_Unit_should_not_be_allowed()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                Measure.FromDecimal(-10, inch, UnitLookup,1)
            );
        }

        [TestMethod]
        public void Unknown_Unit_should_not_be_allowed()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                Measure.FromDecimal(10, "candy", UnitLookup,1)
            );
        }

        [TestMethod]
        public void Throw_when_too_many_decimal_positions()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Measure.FromDecimal((decimal)100.5, pixel, UnitLookup,1)
            );
        }

        [TestMethod]
        public void Throws_on_adding_different_units()
        {
            var firstMeasure = Measure.FromDecimal(5, millimeter, UnitLookup,1);
            var secondMeasure = Measure.FromDecimal(5, pixel, UnitLookup,1);

            Assert.ThrowsException<UnitMismatchException>(() =>
                firstMeasure + secondMeasure
            );
        }

        [TestMethod]
        public void Throws_on_substracting_different_units()
        {
            var firstMeasure = Measure.FromDecimal(5, pixel, UnitLookup,1);
            var secondMeasure = Measure.FromDecimal(5, millimeter, UnitLookup,1);

            Assert.ThrowsException<UnitMismatchException>(() =>
                firstMeasure - secondMeasure
            );
        }

        [TestMethod]
        public void Measure_ToString()
        {
            var firstMeasure = Measure.FromDecimal(5, pixel, UnitLookup, 1);
            var secondMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 3);

            Assert.IsTrue(firstMeasure.ToString() == "5 px" && secondMeasure.ToString() == "5 mm^3");
        }

        [TestMethod]
        public void Multiply_Measures()
        {
            var firstMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 1);
            var secondMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 1);
            var thirdMeasure = Measure.FromDecimal(25, millimeter, UnitLookup, 2);

            Assert.IsTrue((firstMeasure * secondMeasure).Equals( thirdMeasure));
        }
        [TestMethod]
        public void Divide_Measures()
        {
            var firstMeasure = Measure.FromDecimal(15, millimeter, UnitLookup, 2);
            var secondMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 1);
            var thirdMeasure = Measure.FromDecimal(3, millimeter, UnitLookup, 1);

            Assert.IsTrue((firstMeasure / secondMeasure).Equals(thirdMeasure));
        }
        [TestMethod]
        public void Min_Measures()
        {
            var bigMeasure = Measure.FromDecimal(150, millimeter, UnitLookup, 2);
            var smallMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 2);

            Assert.IsTrue((bigMeasure.Min(smallMeasure).Equals(smallMeasure)));
        }
        [TestMethod]
        public void Max_Measures()
        {
            var bigMeasure = Measure.FromDecimal(150, millimeter, UnitLookup, 2);
            var smallMeasure = Measure.FromDecimal(5, millimeter, UnitLookup, 2);

            Assert.IsTrue((bigMeasure.Max(smallMeasure).Equals(bigMeasure)));
        }

    }

}
