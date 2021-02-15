using System;
using Space3DWorld.Framework;


namespace Space3DWorld.Domain
{
    public class Sphere : Shape
    {
        public Sphere(Measure size)
        {
            //Size is diameter
            base.Size = size;
        }
        public override Measure CalculateVolume()
        {
            //formula V = 4/3 πr³
            Measure radius = Size / 2m;
            Decimal factor = (Decimal)(Math.PI * 4 / 3);
            return radius * radius * radius * factor;
        }
        public override Boundarie GetBoundarie(Position position)
        {
            //Boundarie for a Sphere is the boundarie of a cube that contains it
            //NOTE this method can be one-liner, I prefer this clearer but verbose approach :-)
            Measure radius = Size / 2m;
            Measure x1 = position.X - radius;
            Measure x2 = position.X + radius;
            Measure y1 = position.Y - radius;
            Measure y2 = position.Y + radius;
            Measure z1 = position.Z - radius;
            Measure z2 = position.Z + radius;
            return new Boundarie(x1, y1, z1, x2, y2, z2);
        }

        public override Measure IntersectVolume(Position myPosition, Element collider)
        {
            throw new NotImplementedException();
        }
    }
}
