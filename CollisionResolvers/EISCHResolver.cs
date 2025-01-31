﻿using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class EISCHResolver : CollisionResolver
    {
        public override bool HasCellar => false;
        public override String Name => "EISCH";

        public EISCHResolver() { base.rCalculator = new RBottom(); }

        public override void Resolve(int homeAddress, int nodeAddress)
        {
            Node home = (Node)base.storage[homeAddress];
            int nextIndex = home.next;
            home.next = nodeAddress;
            Node newNode = (Node)base.storage[nodeAddress];
            newNode.next = nextIndex;
        }
    }
}
