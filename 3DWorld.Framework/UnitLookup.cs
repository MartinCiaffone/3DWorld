using Space3DWorld.Framework;
using System.Collections.Generic;
using System.Linq;
using static Space3DWorld.Globals;  //C# V6


namespace Space3DWorld.Tests
{
    public class UnitLookup : IUnitLookup
    {

        //(Maybe all this "measures/units/power" thing  is irrelevant in case that for our domain the units were fixed/inmutables)
        private static readonly IEnumerable<UnitDetails> _units =
        new[]
            {
                new UnitDetails
                {
                    UnitCode = pixel,      
                    DecimalPositions = 0,
                    InUse = true
                },
                new UnitDetails                {
                    UnitCode = millimeter,
                    DecimalPositions = 3,
                    InUse = true
                },
                new UnitDetails                {
                    UnitCode = inch,
                    DecimalPositions = 2,
                    InUse = false
                }
            };

        public UnitDetails FindUnit(string unitCode)
        {
            var unit = _units.FirstOrDefault(x => x.UnitCode == unitCode);
            return unit ?? UnitDetails.None; //null-coalescing operator
        }
    }
}
