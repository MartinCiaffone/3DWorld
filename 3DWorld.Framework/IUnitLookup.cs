using System;
using System.Collections.Generic;
using System.Text;

namespace Space3DWorld.Framework
{
    public interface IUnitLookup
    {
        UnitDetails FindUnit(string unitCode);
    }

    public class UnitDetails
    {
        public string UnitCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPositions { get; set; }

        public readonly static UnitDetails None = new UnitDetails { InUse = false };
    }
}
