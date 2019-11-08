using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class RBottom : RCalculator
    {
        public override int getR()
        {
            for (int i = storage.Length - 1; i >= 0; i--)
            {
                if (storage[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
