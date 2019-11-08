using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace file_organization
{
    internal class LISCHResolver : CollisionResolver
    {
        public override void Resolve(int homeAddress, int nodeAddress)
        {
            Console.WriteLine("Resolver");
            //Check if home address is empty
            Node lastNode = (Node) base.storage[homeAddress];
            while (lastNode.next != -1)
            {
                lastNode = (Node) base.storage[lastNode.next];
            }
            lastNode.next = nodeAddress;

        }

        public override bool HasCellar => false;
    }
}
