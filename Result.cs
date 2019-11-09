using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class Result
    {

        public int Address { get; private set; }
        public int Probes { get; private set; }
        public Result(int address, int probes)
        {
            this.Address = address;
            this.Probes = probes;
        }
    }
}
