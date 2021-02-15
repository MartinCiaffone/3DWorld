using System;
using Space3DWorld.Framework;

namespace Space3DWorld.Domain
{
    /// <summary>
    /// It represents a position in a 3D space (X,Y,Z), as we work with solids objects (Elements)
    /// </summary>
    public class Position
    {
        public Measure X { get; }
        public Measure Y { get; }
        public Measure Z { get; }

        public Position(Measure x, Measure y, Measure z)
        {
            //NOTE Here can check, but if I have space/coordinates boundaries to validata it can be done here as properties are of fundamental type (double)
            X = x;
            Y = y;
            Z = z;
        }
    }
}
