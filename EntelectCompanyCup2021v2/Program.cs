using System;
using System.IO;
using
using System.Collections.Generic;

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
            var quotaStartIndex = 1;
            List<Quota> quotas = new List<Quota>();

            var numberOfQuotas = simulation.QuotaCount;
            for(int i = 0; i< numberOfQuotas; i++)
            {
                Quota.Create(lines[quotaStartIndex + i]);
            }

            var clusterStartIndex = 1 + numberOfQuotas;
            // Read resources - UR
            var numberOfResources = simulation.UniqueResources;
            List<ResourceCluster> clusters = new List<ResourceCluster>();
            for (int i = 0; i <= numberOfResources; i++)
            {
                var clusterData = lines[clusterStartIndex + i];
                ResourceCluster.Create
            }


            return simulation;
        }
    }
}
