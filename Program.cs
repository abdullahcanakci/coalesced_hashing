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
            bool running = true;
            while (running)
            {
                Console.Write("Enter number of elements to be checked(0 to exit): ");
                int input = int.Parse(Console.ReadLine());
                if(input == 0)
                {
                    running = false;
                    continue;
                }
                input = input > 900 ? 900 : input;

                int[] protoList = createRandomList(input).ToArray();
                //int[] protoList = new int[] {27, 18, 29, 28, 39, 13, 16, 42, 17};

                Storage lisch = new Storage(new LISCHResolver(), protoList);
                Storage lich = new Storage(new LICHResolver(), protoList);
                Storage eisch = new Storage(new EISCHResolver(), protoList);
                Storage eich = new Storage(new EICHResolver(), protoList);

                Storage beisch = new Storage(new BEISCHResolver(), protoList);
                Storage rlisch = new Storage(new RLISCHResolver(), protoList);

                lisch.PrintTable();
                lich.PrintTable();
                eisch.PrintTable();
                eich.PrintTable();

                beisch.PrintTable();
                rlisch.PrintTable();
            }
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