using Space3DWorld.Framework;
using System;

namespace Space3DWorld.Domain
{
    /// <summary>
    /// Base Class for solids like Cube, Sphere, Prism, Cylinder, etc.
    /// </summary>
    public abstract class Shape
    {
        private Measure _size;
        //Other common attributes (eg. Color) can be here
        public Measure Size
        {
            get { return _size; }
            set
            {
                if (value.Quantity < 0)
                    throw new ArgumentException(
                                "Size cannot be negative",
                                nameof(value));
                if (value.Quantity == 0)
                    throw new ArgumentException(
                                "Size cannot be zero",
                                nameof(value));
                if (value.Power != 1)
                    throw new ArgumentException(
                                "Size power should be 1",
                                nameof(value));
                _size = value;
            }
        }
        public abstract Measure CalculateVolume();
        public abstract Boundarie GetBoundarie(Position position);
        public abstract Measure IntersectVolume(Position myPosition, Element collider);

    }

}
