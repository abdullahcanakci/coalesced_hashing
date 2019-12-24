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
                int numberOfElements;
                if(!int.TryParse(Console.ReadLine(), out numberOfElements))
                {
                    Console.WriteLine("Please enter a valid number between 0 and 900.");
                    continue;
                }

                if(numberOfElements < 0)
                {
                    Console.WriteLine("Input must be a positive integer.");
                    continue;
                }
                
                if(numberOfElements == 0)
                {
                    running = false;
                    continue;
                }
                numberOfElements = numberOfElements > 900 ? 900 : numberOfElements;
                //Math.Max() is not a valid alternative. 
                //It works on bytes for some reason?

                int[] protoList = createRandomList(numberOfElements).ToArray();
                //int[] protoList = new int[] {27, 18, 29, 28, 39, 13, 16, 42, 17};
                //List used in lectures.
                Storage[] storages = new Storage[]
                {
                    new Storage(new LISCHResolver(), protoList),
                    new Storage(new LICHResolver(), protoList),
                    new Storage(new EISCHResolver(), protoList),
                    new Storage(new EICHResolver(), protoList),
                    new Storage(new BEISCHResolver(), protoList),
                    new Storage(new RLISCHResolver(), protoList)
                };

                bool inMenu = true;

                while (inMenu)
                {

                    bool tablePrinting = false, comparePrinting = false, search = false;

                    int input = PrintMenu("Your action?", new List<String>() { "Print tables.", "Print comparison", "Search", "Restart" });

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
                        List<String> names = new List<string>();
                        foreach(var item in storages)
                        {
                            names.Add(item.ResolverName);
                        }
                        names.Add("ALL");
                        names.Add("Next");
                        int select = PrintMenu(
                            "Enter algoritm you want to print table of",
                            names
                        );
                        if(select == names.Count - 1)
                        {
                            tablePrinting = false;
                            continue;
                        }
                        if(select == names.Count - 2)
                        {
                            foreach (var item in storages)
                            {
                                item.PrintTable();
                            }
                            continue;
                        }
                        storages[select].PrintTable();

                        

                    }

                    if (comparePrinting)
                    {
                        Console.WriteLine("{0, 10} |{1}|{2}|{3}|{4}|", "Name", "Packing Factor", "Collision", "Number of Probes", "Probe/Key");
                        foreach (var item in storages)
                        {
                            item.PrintInfo();
                        }
                    }



                    if (search)
                    {
                        Console.WriteLine("Query?");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("{0, 7} | {1, 7} | {2, 5}", "Name", "Address", "Probes");
                        foreach (var item in storages)
                        {
                            item.PrintSearch(key);
                        }
                    }
                }
            }
        }

        public int PrintMenu(String message, List<String> options)
        {
            Console.WriteLine(message);
            for(int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, options[i]);
            }
            bool validEntry = false;
            int input = 0;
            while (!validEntry)
            {
                Console.Write("?");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 0 && input < options.Count)
                    {
                        validEntry = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a selection between 0 and {0}.", (options.Count - 1));
                    }
                } else
                {
                    Console.WriteLine("Please enter a valid number.");
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