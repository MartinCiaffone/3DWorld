using System;

namespace Space3DWorld.Framework
{
    /// <summary>
    /// Measure is a combination of a decimal number (quantity)
    ///                         and a unit code (unit)
    ///                         and ... since our domain is related to geoetric operations: exponent (power)
    /// valid unit codes must be declared, see UnitLookup
    /// Unit has a code or name (UnitCode property), can be disabled (InUse property) and has a number of decimals allowed (DecimalPositions property)
    /// Detects different units present on attemp for operations
    /// It can be extended to have unit conversion capabilities
    /// Power is the exponent in the exponentiation mathematical operation
    /// For our domain should be only 1, 2, and 3 powers (1D, 2D, 3D), but is not enforced in this version in case will be grow to a more advanced operations.
    /// (Value Objects)(Operator Overloading)(Factory)
    /// </summary>
    public class Measure
    {
        public static Measure FromDecimal(decimal quantity, string unit,
            IUnitLookup unitLookup, int power) =>
            new Measure(quantity, unit, unitLookup, power);

        public static Measure FromString(string quantity, string unit,
            IUnitLookup unitLookup, int power) =>
            new Measure(decimal.Parse(quantity), unit, unitLookup, power); //Warning : Beware of System.Globalization.CultureInfo.CurrentCulture
        protected Measure(decimal quantity, string unitCode, IUnitLookup unitLookup, int power)
        {
            if (string.IsNullOrEmpty(unitCode))
                throw new ArgumentNullException(
                    nameof(unitCode), "Unit code must be specified");

            var unit = unitLookup.FindUnit(unitCode);
            if (!unit.InUse)
                throw new ArgumentException($"Unit {unitCode} is not valid");

            if (decimal.Round(quantity, unit.DecimalPositions) != quantity)
                throw new ArgumentOutOfRangeException(
                    nameof(quantity),
                    $"Quantity in {unitCode} cannot have more than {unit.DecimalPositions} decimals");

            Quantity = quantity;
            Unit = unit;
            Power = power;
        }

        protected Measure(decimal quantity, UnitDetails unit, int power)
        {
            Quantity = quantity;
            Unit = unit;
            Power = power;
        }

        public decimal Quantity { get; }
        public UnitDetails Unit { get; }
        public int Power { get; }

        public bool Equals(Measure other)
        {
            return (Quantity == other.Quantity && Unit == other.Unit && Power == other.Power);  
        }

        public Measure Add(Measure summand)
        {
            if (Unit != summand.Unit)
                throw new UnitMismatchException(
                    "Cannot sum quantities with different units");

            return new Measure(Quantity + summand.Quantity, Unit, Power);
        }

        public Measure Subtract(Measure subtrahend)
        {
            if (Unit != subtrahend.Unit)
                throw new UnitMismatchException(
                    "Cannot subtract quantities with different units");

            return new Measure(Quantity - subtrahend.Quantity, Unit, Power);
        }
        public Measure Multiply(Measure multiplier)
        {
            if (Unit != multiplier.Unit)
                throw new UnitMismatchException(
                    "Cannot multiply quantities with different units");
            //here we can enforce: Power+multiplier.Power <= 3 (means should be on 3 Dimension realm)
            return new Measure(Math.Round(Quantity * multiplier.Quantity,Unit.DecimalPositions), Unit, Power+multiplier.Power);
        }
        public Measure Multiply(Decimal multiplier)
        {
            return new Measure(Math.Round(Quantity * multiplier, Unit.DecimalPositions), Unit, Power);
        }
        public Measure Divide(Measure divisor)
        {
            if (Unit != divisor.Unit)
                throw new UnitMismatchException(
                    "Cannot divide quantities with different units");
            //here we can enforce: Power-multiplier.Power >= 1 (means should be on 3 Dimension realm)
            return new Measure(Math.Round(Quantity / divisor.Quantity,Unit.DecimalPositions), Unit, Power - divisor.Power);
        }
        public Measure Divide(decimal divisor)
        {
            return new Measure(Math.Round(Quantity / divisor,Unit.DecimalPositions) , Unit, Power);
        }
        public Measure Max(Measure comparer)
        {
            if (Unit != comparer.Unit)
                throw new UnitMismatchException(
                    "Cannot compare (Max) quantities with different units");
            if (Power != comparer.Power)
                throw new UnitMismatchException(
                    "Cannot compare (Max) quantities with different exponents");
            return new Measure(Math.Round(Math.Max(Quantity, comparer.Quantity), Unit.DecimalPositions), Unit, Power);
        }
        public Measure Max(decimal comparer)
        {
            return new Measure(Math.Round(Math.Max(Quantity, comparer), Unit.DecimalPositions), Unit, Power);
        }
        public Measure Min(Measure comparer)
        {
            if (Unit != comparer.Unit)
                throw new UnitMismatchException(
                    "Cannot compare (Min) quantities with different units");
            if (Power != comparer.Power)
                throw new UnitMismatchException(
                    "Cannot compare (Min) quantities with different exponents");
            return new Measure(Math.Round(Math.Min(Quantity, comparer.Quantity), Unit.DecimalPositions), Unit, Power);
        }
        public Measure Min(decimal comparer)
        {
            return new Measure(Math.Round(Math.Min(Quantity, comparer), Unit.DecimalPositions), Unit, Power);
        }


        public static Measure operator +(Measure summand1, Measure summand2) =>
            summand1.Add(summand2);

        public static Measure operator -(Measure minuend, Measure subtrahend) =>
            minuend.Subtract(subtrahend);
        public static Measure operator *(Measure multiplicand, Measure multiplier) =>
            multiplicand.Multiply(multiplier);
        public  static Measure operator *(Measure multiplicand, decimal multiplier) =>
            multiplicand.Multiply(multiplier);
        public  static Measure operator /(Measure dividend, Measure divisor) =>
            dividend.Divide(divisor);
        public static Measure operator /(Measure dividend, decimal divisor) =>
            dividend.Divide(divisor);

        public override string ToString() => (Power!=1?$"{Quantity} {Unit.UnitCode}^{Power}":$"{Quantity} {Unit.UnitCode}");  //Don't show power when the exponent is 1 
    }

    public class UnitMismatchException : Exception
    {
        public UnitMismatchException(string message) : base(message)
        {
            //Need customize something? here is a good place.
        }
    }
}
