using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class BEISCHResolver : EISCHResolver
    {
        public override String Name => "BEISCH";

        public BEISCHResolver() { base.rCalculator = new RBidirectional(); }
    }
}
