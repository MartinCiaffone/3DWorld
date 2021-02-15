using System;
using System.Collections.Generic;
using System.Text;
using Space3DWorld.Framework;

namespace Space3DWorld.Domain
{
    public class Boundarie
    {
        //To match the space geometry domain y show boundaries with a proper notation
        public Measure X1 { get { return _positionStart.X; } }
        public Measure Y1 { get { return _positionStart.Y; } }
        public Measure Z1 { get { return _positionStart.Z; } }
        public Measure X2 { get { return _positionEnd.X; } }
        public Measure Y2 { get { return _positionEnd.Y; } }
        public Measure Z2 { get { return _positionEnd.Z; } }

        //We use two Positions to define a boundarie to have coord. validation in one place.
        private readonly Position _positionStart;
        private readonly Position _positionEnd;

        public Boundarie(Measure x1, Measure y1, Measure z1, Measure x2, Measure y2, Measure z2)
        {
            _positionStart = new Position(x1, y1, z1);
            _positionEnd = new Position(x2, y2, z2);
        }

        public override string ToString() => ($"(x1;x2)=({X1.Quantity};{X2.Quantity})  (y1;y2)=({Y1.Quantity};{Y2.Quantity})  (z1;z2)=({Z1.Quantity};{Z2.Quantity})");

    }
}
