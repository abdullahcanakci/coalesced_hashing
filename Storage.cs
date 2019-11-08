using System;
using System.Collections.Generic;
using System.Text;

namespace file_organization
{
    class Storage
    {
        private CollisionResolver resolver;
        private RCalculator rCalculator;
        private int storageLimit;
        private Node[] storage;

        public int Length => storage.Length;

        public Storage(CollisionResolver resolver, RCalculator rCalc, int capacity)
        {
            this.storage = new Node[(int)(capacity * 1.1)];
            this.resolver = resolver;
            this.rCalculator = rCalc;

            this.resolver.storage = storage;
            this.rCalculator.storage = storage;
            
            storageLimit = storage.Length;
            if (resolver.HasCellar)
            {
                storageLimit = (int)(storageLimit * 0.86);
            }
        }

        public int Add(int key)
        {
            int homeAddress = GetHash(key) % storageLimit; //TODO should be prime

            Node node = new Node(key);
            if (storage[homeAddress] == null)
            {
                storage[homeAddress] = node;
            } else
            {
                int R = rCalculator.getR();
                if(R == -1)
                {
                    return -1;
                } else
                {
                    storage[R] = node;
                    resolver.Resolve(homeAddress, R);
                }
            }
            return -1;
        }

        private int GetHash(int key)
        {
            return (key + key % 10 + (int)Math.Sqrt(key));
        }

        public void PrintTable()
        {
            Console.Write("   ");
            for(int i = 0; i < 20; i++)
            {
                Console.Write('|' + i.ToString().PadLeft(5, '\0').PadRight(8,'\0'));
            }
            Console.WriteLine("|");
            for(int row = 0; row <= this.Length / 20; row++)
            {
                Console.Write(row.ToString().PadRight(3));
                int itemsInRow = 20;
                if(storage.Length - itemsInRow * row < itemsInRow)
                {
                    itemsInRow = storage.Length - itemsInRow * row;
                }
                for(int column = 0; column < itemsInRow; column++)
                {
                    Node item = storage[20 * row + column];
                    if (item != null)
                    {
                        var KeyString = item.key.ToString();
                        var NextString = item.next == -1 ? "#" : item.next.ToString();
                        Console.Write('|' + KeyString.PadLeft(4, '\0') + '-' + NextString.PadLeft(3, '\0'));
                    }else
                    {
                        Console.Write("|    -   ");
                    }
                }
                Console.WriteLine("|");
            }
        }

        public Node Get(int index)
        {
            return storage[index];
        }
    }
}
