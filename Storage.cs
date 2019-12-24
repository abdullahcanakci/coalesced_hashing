using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    /// <summary>
    /// Handles a storage area all responsibility.
    /// 
    /// </summary>
    class Storage
    {
        private CollisionResolver resolver;
        private int storageLimit;
        private Node[] storage;
        private int storagePrime;

        public int Count { get; private set; } = 0;
        public int NumberOfCollisions { get; private set; } = 0;
        public int NumberOfProbes { get; private set; } = 0;
        public int Capacity => storage.Length;
        public double PackingFactor => (Count/(double)storagePrime) * 100;
        public double ProbePerKey => NumberOfProbes / (double)Count;

        public String ResolverName => resolver.Name;

        public Storage(CollisionResolver resolver, int capacity)
        {
            this.storagePrime = CalculateStorageSize(capacity);
            this.storage = new Node[storagePrime];
            this.resolver = resolver;

            this.resolver.storage = storage;
            
            storageLimit = storage.Length;
            if (resolver.HasCellar)
            {
                storageLimit = CalculateStorageSize((int)(storageLimit * 0.80));
                // Vitter, Jeffrey. (1982). Implementations for Coalesced Hashing.. Commun. ACM. 25. 911-926. 10.1145/358728.358745. 
                // for PF90 graph on page 915 shows that 79-80%
            }
        }

        public Storage(CollisionResolver resolver, int[] list) : this(resolver, list.Length)
        {
            this.AddRange(list);
            this.CalculateProbeNumber(list);
        }

        /// <summary>
        /// Storage size must be no larger than number of items * 1.1.
        /// By design we are required to have ~90% packing factor and this should ensure it.
        /// Number of elements must be prime otherwise collisions might occur just because of the storage size.
        /// </summary>
        /// <param name="capacity">Number of items to be stored.</param>
        /// <returns>Calculated storage size.</returns>
        private int CalculateStorageSize(int capacity)
        {
            int limit = (int)(capacity * 1.1);
            for(int i = limit; i > capacity; i--)
            {
                if (IsPrime(i))
                {
                    return i;
                }
            }
            return CalculateStorageSize((int)(Math.Ceiling(capacity*1.1)));
        }

        /// <summary>
        /// Prime check algorithm.
        /// Will be used while calculating storage size so we can use prime divisors.
        /// </summary>
        private bool IsPrime(int n)
        {
            //AKS primality test
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int Add(int key)
        {
            int homeAddress = GetHomeAddress(key);

            Node node = new Node(key);
            if (storage[homeAddress] == null)
            {
                storage[homeAddress] = node;
                this.Count++;
            } else
            {
                this.NumberOfCollisions++;
                int R = resolver.RPointer;
                if(R == -1) // is full
                {
                    return -1;
                } else
                {
                    storage[R] = node;
                    resolver.Resolve(homeAddress, R);
                    this.Count++;
                }
            }
            return -1;
        }

        public void AddRange(int[] keys)
        {
            foreach (var item in keys)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Given a array of key it will calculate number of probes to reach every element
        /// </summary>
        public void CalculateProbeNumber(int[] keys)
        {
            foreach(var item in keys)
            {
                NumberOfProbes += Find(item).Probes;
            }
        }

        public Result Find(int key)
        {
            int probes = 1;
            int homeAddress = GetHomeAddress(key);

            if(storage[homeAddress] == null)
            {
                return new Result(-1, probes);
            }
            if(storage[homeAddress].key == key)
            {
                return new Result(homeAddress, probes);
            }

            while(storage[homeAddress].key != key)
            {
                probes++;
                if (storage[homeAddress].next == -1) { break; }
                homeAddress = storage[homeAddress].next;
            }
            
            if(storage[homeAddress].key != key)
            {
                return new Result(-1, probes);
            }
            return new Result(homeAddress, probes);   
        }

        private int GetHomeAddress(int key)
        {
            return (int)(GetHash(key) % this.storageLimit);
            
        }

        private long GetHash(int key)
        {
            //return key;
            return Math.Abs(key.ToString().GetHashCode());
        }

        public void PrintTable()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            
            Console.Write("\n\nAlgorithm Name: {0} | ", this.resolver.Name);
            Console.Write("Number of Items: {0} | Capacity: {1} | ", this.Count, this.Capacity);
            Console.Write("Packing Factor: {0:0.00} | ", this.PackingFactor);
            Console.Write("Collisions: {0} | ", this.NumberOfCollisions);
            Console.Write("Probe Number: {0} | ", this.NumberOfProbes);
            Console.Write("Probe/Key: {0:0.000} |\n\n", this.ProbePerKey);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Ind");
            for(int i = 0; i < 15; i++)
            {
                Console.Write("|{0}", i.ToString().PadLeft(5).PadRight(9));
            }
            Console.WriteLine("|");
            for(int row = 0; row <= this.Capacity / 15; row++)
            {
                if(row % 2 != 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }

                Console.Write("{0, -3}", row*15);

                int itemsInRow = 15;
                if(storage.Length - itemsInRow * row < itemsInRow)
                {
                    itemsInRow = storage.Length - itemsInRow * row;
                }
                for(int column = 0; column < itemsInRow; column++)
                {
                    Node item = storage[15 * row + column];
                    if (item != null)
                    {
                        var KeyString = item.key.ToString();
                        var NextString = item.next == -1 ? "#" : item.next.ToString();
                        Console.Write("|{0, 4}-{1, 4}", KeyString, NextString);
                    }else
                    {
                        Console.Write("|    -    ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintInfo()
        {
            Console.Write("{0, 11}| ", this.resolver.Name);
            Console.Write("{0, 13 :0.00}| ", this.PackingFactor);
            Console.Write("{0, 8}| ", this.NumberOfCollisions);
            Console.Write("{0, 15}| ", this.NumberOfProbes);
            Console.Write("{0, 8 :0.000}|\n", this.ProbePerKey);
        }

        public void PrintSearch(int key)
        {
            Result r = Find(key);
            Console.Write("{0, 7} | {1, 7} | {2, 5}\n", this.resolver.Name, r.Address == -1 ? "N/A" : r.Address.ToString(), r.Probes);
        }
        public Node Get(int index)
        {
            return storage[index];
        }
    }
}
