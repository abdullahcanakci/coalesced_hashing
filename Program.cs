using System;
using System.Collections;
using System.Collections.Generic;

namespace file_organization
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            app.Run();


        }

        public void Run()
        {
            List<int> protoList = createRandomList(900);
            //List<int> protoList = new List<int>(new int[] {27, 18, 29, 28, 39, 13, 16, 42, 17});

            Storage storage = new Storage(new LISCHResolver(), new RBottom(), protoList.Count);


            
            foreach (var item in protoList)
            {
                storage.Add(item);
            }

            storage.PrintTable();
        }

        public List<int> createRandomList(int numberOfElements)
        {
            List<int> randomList = new List<int>(numberOfElements);
            Random r = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                randomList.Add(r.Next(0, 5000));
            }
            return randomList;
        }

        public void printArray(ArrayList list)
        {
            int itemsInRow = 25;
            int itemCountInRow = 0;
            foreach (var i in list)
            {
                Console.Write(i.ToString().PadLeft(5));
                itemCountInRow++;
                if (itemCountInRow == itemsInRow)
                {
                    Console.Write("\n");
                    itemCountInRow = 0;
                }
            }
            Console.Write("\n");
        }


    }
}