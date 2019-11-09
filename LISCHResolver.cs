using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace file_organization
{
    internal class LISCHResolver : CollisionResolver
    {
        public override bool HasCellar => false;

        public override String Name => "LISCH";

        public LISCHResolver () { base.rCalculator = new RBottom(); }

        public override void Resolve(int homeAddress, int nodeAddress)
        {
            //Check if home address is empty
            Node lastNode = (Node) base.storage[homeAddress];
            while (lastNode.next != -1)
            {
                lastNode = (Node) base.storage[lastNode.next];
            }
            lastNode.next = nodeAddress;

        }
    }
}
