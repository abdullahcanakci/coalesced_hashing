using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class EICHResolver : EISCHResolver
    {
        public override bool HasCellar => true;
        public override String Name => "EICH";

        public EICHResolver() { base.rCalculator = new RBottom(); }
    }
}
