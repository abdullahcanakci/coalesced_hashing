using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class RLISCHResolver : LISCHResolver
    {
        public override bool HasCellar => false;

        public override string Name => "RLISCH";

        public RLISCHResolver() { base.rCalculator = new RRandom(); }
    }
}
