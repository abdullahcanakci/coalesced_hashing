using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class EICHResolver : EISCHResolver
    {
        public override bool HasCellar => true;
    }
}
