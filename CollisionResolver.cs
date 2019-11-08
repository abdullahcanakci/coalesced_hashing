using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    internal abstract class CollisionResolver
    {
        public Node[] storage;

        public abstract void Resolve(int homeAddress, int nodeAddress);

        public abstract bool HasCellar { get; }
        public abstract String Name { get; }
    }
}