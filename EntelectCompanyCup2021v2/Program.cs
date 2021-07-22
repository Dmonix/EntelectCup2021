using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EntelectCompanyCup2021v2
{
    class Program
    {
        public static List<Resource> Resources = new List<Resource>()
        {
            new Resource(1, "Adamantium", 1, 2, 2, 1m, 8),
            new Resource(2, "Madamantium", 1, 2, 2, 1m, 9),
            new Resource(3, "Sadamantium", 1, 2, 3, 0.66667m, 10),
            new Resource(4, "Gladamantium", 2, 4, 3, 1.33333m, 3),
            new Resource(5, "Radamantium", 2, 4, 3, 1.33333m, 4),
            new Resource(6, "Badamantium", 2, 4, 4, 1m, 7),
            new Resource(7, "Chocolate", 3, 6, 4, 1.5m, 1),
            new Resource(8, "Antmanium", 3, 6, 5, 1.2m, 6),
            new Resource(9, "Vladamantium", 4, 8, 6, 1.5m, 2),
            new Resource(10, "Vibranium", 5, 10, 8, 1.25m, 5)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var inputFileNumber = 1;
            var sim = ReadFile($"{inputFileNumber}.txt");

            // do things
            string[] outputContent = new string[] { "test", "test"};

            // generate output
            OutputFile($"output-{inputFileNumber}.txt", outputContent);
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
                quotas.Add(Quota.Create(lines[quotaStartIndex + i]));
            }
            simulation.Quotas = quotas;

            var clusterStartIndex = numberOfQuotas + quotaStartIndex;
            // Read resources - UR
            var numberOfResources = simulation.UniqueResources;
            List<ResourceCluster> clusters = new List<ResourceCluster>();
            for (int i = 0; i < numberOfResources; i++)
            {
                var clusterData = lines[clusterStartIndex + i];
                var clusterInfo = clusterData.Split('|');
                for(var x = 1; x<clusterInfo.Length; x++)
                {

                    clusters.Add(ResourceCluster.Create(clusterInfo[0], clusterInfo[x]));
                }
            }
            simulation.Clusters = clusters;


            return simulation;
        }

        static void OutputFile(string name, string [] lines)
        {
            var content = "";
            foreach(var line in lines)
            {
                content = content + line + "\n";
            }

            File.WriteAllText(name, content);
        }
    }
}
