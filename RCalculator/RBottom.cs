using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    /// <summary>
    /// R calculation from bottom of a storage area
    /// </summary>
    class RBottom : RCalculator
    {
        public override int getR(Node[] storage)
        {
            for (int i = storage.Length - 1; i >= 0; i--)
            {
                if (storage[i] == null)
                {
                    return i;
                }
            }
            // -1 really should not be returned
            // Request origin has the capability to check if the storage area is full without iteration
            return -1;
        }
    }
}
