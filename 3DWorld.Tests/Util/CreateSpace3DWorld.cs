using System;
using Space3DWorld.Domain;
using Space3DWorld.Framework;
using static Space3DWorld.Globals;  //C# V6

namespace Space3DWorld.Tests
{
    public class CreateSpace3DWorld

    {
        private static readonly IUnitLookup UnitLookup = new UnitLookup();

        public static Measure Zero = Measure.FromDecimal(0, pixel, UnitLookup, 1);
        private static Measure One = Measure.FromDecimal(1, pixel, UnitLookup, 1);
        private static Measure HalfRight = Measure.FromDecimal(25, pixel, UnitLookup, 1);
        private static Measure FarAway = Measure.FromDecimal(1000, pixel, UnitLookup, 1);

        private static Measure SizeFive = Measure.FromDecimal(50, pixel, UnitLookup, 1);
        private static Measure SizeTen = Measure.FromDecimal(100, pixel, UnitLookup, 1);

        public static ElementId ElementIdOne = new ElementId(Guid.NewGuid());
        public static ElementId ElementIdTwo = new ElementId(Guid.NewGuid());

        public static Position PositionOne = new Position(One, One, One);

        public static Cube Cube05 = new Cube(SizeFive);
        public static Cube Cube10 = new Cube(SizeTen);
        public static Sphere Sphere10 = new Sphere(SizeTen);

        public Element ElementS10One = new Element(ElementIdOne, PositionOne, Sphere10);
        public Element ElementC05One = new Element(ElementIdTwo, PositionOne, Cube05);

        //Other way to create an Element
        public Element ElementC05Zero = new Element(new ElementId(Guid.NewGuid()), new Position(Zero, Zero, Zero), new Cube(SizeFive));
        public Element ElementC05FarAway = new Element(new ElementId(Guid.NewGuid()), new Position(FarAway, FarAway, FarAway), new Cube(SizeFive));
        public Element ElementC05HalfRight = new Element(new ElementId(Guid.NewGuid()), new Position(HalfRight, Zero, Zero), new Cube(SizeFive));

        public CreateSpace3DWorld()
        {
            //Need more initalizations?
        }
    }
}
