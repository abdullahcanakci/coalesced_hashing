using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    /// <summary>
    /// Finds a random spot on storage to prevent overcrowding regions of storage.
    /// </summary>
    class RRandom : RCalculator
    {
        public override int getR(Node[] storage)
        {
            Random r = new Random();
            for(int i = 0; i < storage.Length; i++)
            {
                int rand = r.Next(0, storage.Length);
                if(storage[rand] == null)
                {
                    return rand;
                }
            }
            return -1;
        }
    }
}
