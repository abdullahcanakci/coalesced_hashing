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
            //Non static App run
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Write("Enter number of elements to be checked(0 to exit): ");
                int numberOfElements = int.Parse(Console.ReadLine());
                if(numberOfElements == 0)
                {
                    running = false;
                    continue;
                }
                numberOfElements = numberOfElements > 900 ? 900 : numberOfElements;

                int[] protoList = createRandomList(numberOfElements).ToArray();
                //int[] protoList = new int[] {27, 18, 29, 28, 39, 13, 16, 42, 17};

                Storage lisch = new Storage(new LISCHResolver(), protoList);
                Storage lich = new Storage(new LICHResolver(), protoList);
                Storage eisch = new Storage(new EISCHResolver(), protoList);
                Storage eich = new Storage(new EICHResolver(), protoList);

                Storage beisch = new Storage(new BEISCHResolver(), protoList);
                Storage rlisch = new Storage(new RLISCHResolver(), protoList);

                bool inMenu = true;

                while (inMenu)
                {

                    bool tablePrinting = false, comparePrinting = false, search = false;

                    int input = PrintMenu("Your action?", new string[] { "Print tables.", "Print comparison", "Search", "Restart" });

                    switch (input)
                    {
                        case 0:
                            tablePrinting = true;
                            break;
                        case 1:
                            comparePrinting = true;
                            break;
                        case 2:
                            search = true;
                            break;
                        case 3:
                            inMenu = false;
                            break;
                    }

                    while (tablePrinting)
                    {
                        int select = PrintMenu(
                            "Enter algoritm you want to print table of",
                            new string[] {
                            "Next",
                            "LISCH",
                            "LICH",
                            "EISCH",
                            "EICH",
                            "BEISCH",
                            "RLISCH",
                            "ALL"
                            }
                        );
                        switch (select)
                        {
                            case 0:
                                tablePrinting = false;
                                continue;
                            case 1:
                                lisch.PrintTable();
                                break;
                            case 2:
                                lich.PrintTable();
                                break;
                            case 3:
                                eisch.PrintTable();
                                break;
                            case 4:
                                eich.PrintTable();
                                break;
                            case 5:
                                beisch.PrintTable();
                                break;
                            case 6:
                                rlisch.PrintTable();
                                break;
                            case 7:
                                lisch.PrintTable();
                                lich.PrintTable();
                                eisch.PrintTable();
                                eich.PrintTable();

                                beisch.PrintTable();
                                rlisch.PrintTable();
                                break;
                            default:
                                break;
                        }

                    }

                    if (comparePrinting)
                    {
                        Console.WriteLine("{0, 10} |{1}|{2}|{3}|", "Name", "Packing Factor", "Collision", "Number of Probes");
                        lisch.PrintInfo();
                        lich.PrintInfo();
                        eisch.PrintInfo();
                        eich.PrintInfo();
                        beisch.PrintInfo();
                        rlisch.PrintInfo();
                    }



                    if (search)
                    {
                        Console.WriteLine("Query?");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("{0, 7} | {1, 7} | {2, 5}", "Name", "Address", "Probes");
                        lisch.PrintSearch(key);
                        lich.PrintSearch(key);
                        eisch.PrintSearch(key);
                        eich.PrintSearch(key);
                        beisch.PrintSearch(key);
                        rlisch.PrintSearch(key);
                    }



                }
            }
        }

        public int PrintMenu(String message, string[] options)
        {
            Console.WriteLine(message);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, options[i]);
            }
            bool validEntry = false;
            int input = 0;
            while (!validEntry)
            {
                input = int.Parse(Console.ReadLine());
                if(input >= 0 || input < options.Length)
                {
                    validEntry = true;
                }
                
            }
            return input;
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