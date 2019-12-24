using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    internal class LICHResolver : LISCHResolver
    {
        public override bool HasCellar => true;
        public override String Name => "LICH";

        public LICHResolver() { base.rCalculator = new RBottom(); }
    }
}
