using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    /// <summary>
    /// Class to implement R calculations for empty regions of storage.
    /// </summary>
    public abstract class RCalculator
    { 
        /// <summary>
        /// Finds a convenient area to store element
        /// </summary>
        /// <param name="storage">Storage array to search against</param>
        /// <returns>An empty index value</returns>
        public abstract int getR(Node[] storage);
    }
}
