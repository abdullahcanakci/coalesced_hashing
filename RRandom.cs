using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
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
