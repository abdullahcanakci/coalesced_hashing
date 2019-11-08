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
            bool programRunning = true;
            List<int> protoList = createRandomList(30);

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
                randomList.Add(r.Next(0, 60));
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