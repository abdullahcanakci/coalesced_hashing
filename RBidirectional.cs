using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class RBidirectional : RCalculator
    {
        private bool fromBottom = false;

        public override int getR(Node[] storage)
        {
            int response = -1;
            if (fromBottom)
            {
                for (int i = storage.Length - 1; i >= 0; i--)
                {
                    if (storage[i] == null)
                    {
                        response = i;
                    }
                }
            } else
            {
                for (int i = 0; i <= storage.Length - 1; i++)
                {
                    if (storage[i] == null)
                    {
                        response = i;
                    }
                }
            }
            fromBottom = !fromBottom;
            return response;
        }
    }
}
