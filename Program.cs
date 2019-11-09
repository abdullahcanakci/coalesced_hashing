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
            List<int> protoList = createRandomList(22);
            //List<int> protoList = new List<int>(new int[] {27, 18, 29, 28, 39, 13, 16, 42, 17});

            Storage lisch = new Storage(new LISCHResolver(), protoList.Count);

            Storage beisch = new Storage(new BEISCHResolver(), protoList.Count);
            
            foreach (var item in protoList)
            {
                lisch.Add(item);
                beisch.Add(item);
            }

            lisch.PrintTable();
            beisch.PrintTable();
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
    }
}