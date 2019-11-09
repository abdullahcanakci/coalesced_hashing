using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    internal abstract class CollisionResolver
    {
        public Node[] storage;

        internal RCalculator rCalculator;

        public abstract void Resolve(int homeAddress, int nodeAddress);
        
        public int RPointer { get => rCalculator.getR(storage); }
        public abstract bool HasCellar { get; }

        public abstract String Name { get; }
    }
}