using Space3DWorld.Framework;

namespace Space3DWorld.Domain
{
    /// <summary>
    /// An Element is a solid 3D geometric figure (class Shape) that has a position in our "World" (class Position)
    /// </summary>
    public class Element
    {

        public ElementId Id { get; private set; } //(Value Element pattern)
        public Shape ElementShape { get; private set; }
        public Position ElementPosition { get; private set; }

        public Element(ElementId id, Position position, Shape shape)
        {
            Id = id;
            ElementPosition = position;
            ElementShape = shape;
        }

        public Measure IntersectedVolume(Element OtherElement)
        {
            //This Element method calculates the intersected volumen with another element.
            //This calculation is different for every pair of shapes (relies on the shape type).
            //This operation is commutative, that is, the volume of the intersection of shape A with shape B, whatever its type, 
            // is the same as the intersection of shape B with shape A.
            //NOTE: for demonstration purposes we implement the intersection between two cubes with parallel sides.
            return ElementShape.IntersectVolume(ElementPosition, OtherElement);
        }

        public Boundarie GetBoundarie()
        {
            return ElementShape.GetBoundarie(ElementPosition);
        }

    }
}
