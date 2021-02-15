using System;
using Space3DWorld.Framework;

namespace Space3DWorld.Domain
{
    public class Cube : Shape
    {
        public Cube(Measure size)
        {
            //Size is edge lenght
            base.Size = size;
        }
        public override Measure CalculateVolume()
        {
            //formula V = l³
            return (Size * Size * Size);
        }
        public override Boundarie GetBoundarie(Position position)
        {
            //NOTE this method can be one-liner, I prefer this clearer but verbose approach :-)
            Measure halfEdge = Size / 2m;
            Measure x1 = position.X - halfEdge;
            Measure x2 = position.X + halfEdge;
            Measure y1 = position.Y - halfEdge;
            Measure y2 = position.Y + halfEdge;
            Measure z1 = position.Z - halfEdge;
            Measure z2 = position.Z + halfEdge;
            return new Boundarie(x1, y1, z1, x2, y2, z2);
        }

        public override Measure IntersectVolume(Position myPosition, Element collider)
        {
            if (collider.ElementShape is Cube)
            { //NOTE Only Cube-Cube intersect implemented.
                Boundarie myBoundarie = this.GetBoundarie(myPosition);
                Boundarie colliderBoundarie = collider.ElementShape.GetBoundarie(collider.ElementPosition);
                return OverlapSide(myBoundarie.X1, myBoundarie.X2, colliderBoundarie.X1, colliderBoundarie.X2)
                     * OverlapSide(myBoundarie.Y1, myBoundarie.Y2, colliderBoundarie.Y1, colliderBoundarie.Y2)
                     * OverlapSide(myBoundarie.Z1, myBoundarie.Z2, colliderBoundarie.Z1, colliderBoundarie.Z2);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        //1d ovelapping
        private Measure OverlapSide(Measure a1, Measure a2, Measure b1, Measure b2)
        {
            return (a2.Min(b2) - a1.Max(b1)).Max(0);
        }
    }

}
