using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    public abstract class RCalculator
    {
        public Node[] storage;

        public abstract int getR();
    }
}
