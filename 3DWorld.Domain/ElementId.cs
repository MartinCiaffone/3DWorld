using System;

namespace Space3DWorld.Domain
{
    public class ElementId
    {
        private readonly Guid _value;
        public ElementId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "3D Element 'id' cannot be empty");

            _value = value;
        }

        public static implicit operator Guid(ElementId self) => self._value; //To simplify the assignments between entity properties and event properties (Although, I am not using event properties yet)
        
    }
}
