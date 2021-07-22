using System;
using System.IO;
using 

namespace EntelectCompanyCup2021v2
{
    class Program
    {
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
            for(int i = 0; i< numberOfQuotas; i++)
            {

            }

            // Read resources - UR
            var numberOfResources = simulation.UniqueResources;
            for (int i = 1+ numberOfQuotas; i <= numberOfResources; i++)
            {

            }


            return simulation;
        }
    }
}
