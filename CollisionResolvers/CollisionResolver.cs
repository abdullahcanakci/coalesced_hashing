using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    internal abstract class CollisionResolver
    {
        /// <summary>
        /// Main storage area, will resolve against
        /// </summary>
        public Node[] storage;

        internal RCalculator rCalculator;

        public abstract void Resolve(int homeAddress, int nodeAddress);
        
        public int RPointer { get => rCalculator.getR(storage); }
        /// <summary>
        /// If has cellar we need to create an empty space at the end of the storage.
        /// This overflow storage will be use in case of collisions.
        /// If overflow storage is filled. It will continue from end of the main storage.
        /// </summary>
        public abstract bool HasCellar { get; }

        public abstract String Name { get; }
    }
}