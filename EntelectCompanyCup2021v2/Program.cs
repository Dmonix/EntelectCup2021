using System;
using System.Collections.Generic;
using System.IO;

namespace EntelectCompanyCup2021v2
{
    class Program
    {
        public static List<Resource> Resources = new List<Resource>()
        {
            new Resource(1, "Adamantium", 1, 2, 2, 1m),
            new Resource(2, "Madamantium", 1, 2, 2, 1m),
            new Resource(3, "Sadamantium", 1, 2, 3, 0.66667m),
            new Resource(4, "Gladamantium", 2, 4, 3, 1.33333m),
            new Resource(5, "Radamantium", 2, 4, 3, 1.33333m),
            new Resource(6, "Badamantium", 2, 4, 4, 1m),
            new Resource(7, "Chocolate", 3, 6, 4, 1.5m),
            new Resource(8, "Antmanium", 3, 6, 5, 1.2m),
            new Resource(9, "Vladamantium", 4, 8, 6, 1.5m),
            new Resource(10, "Vibranium", 5, 10, 8, 1.25m)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sim = ReadFile("input.txt");
        }

        static Simulation ReadFile(string inputFileName)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            // Generate sim
            var simInfo = lines[0]; // first line
            var simulation = Simulation.Create(simInfo);

            // Read quotas - NQ
            var numberOfQuotas = simulation.QuotaCount;

            // Read resources - UR
            var numberOfResources = simulation.UniqueResources;



            return simulation;
        }
    }
}
