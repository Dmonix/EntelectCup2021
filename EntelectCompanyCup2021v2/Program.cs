using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntelectCompanyCup2021v2
{
    static class Program
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
            List<int> inputFiles = new List<int>() { 1, 2, 3, 4, 5 };

            foreach(var file in inputFiles)
            {
                var sim = ReadFile($"{file}.txt");

                // do things
                var outputContent = Traverse(sim);

                // generate output
                OutputFile($"output-{file}.txt", outputContent);
            }
        }

        static string[] Traverse(Simulation sim)
        {
            var ships = sim.ShipCount;
            var quotas = sim.Quotas.OrderBy(q => q.QuotaAmount).ToList();

            var allResourceClusters = new List<ResourceCluster>();
            foreach(var quota in quotas)
            {
                var subClusters = sim.Clusters
                     .Where(c => c.ResourceId == quota.ResourceId)
                     .OrderByDescending(c => c.NumberOfResources)
                     .ThenBy(c => c.DistanceFromCenter)
                     .ToList();
                allResourceClusters.AddRange(subClusters);
            }

            List<string> output  = new List<string>();

            var startingResource = 0;
            for (var x = 0; x<ships; x++)
            {
                List<string> resourceClusterIds = new List<string>() ;

                var shipCapacity = sim.ShipCapacity;
                
                for(var y = startingResource; y< allResourceClusters.Count; y++) { 
                    if(shipCapacity - allResourceClusters[y].NumberOfResources > 0)
                    {
                        if (y == allResourceClusters.Count -1)
                        {
                            resourceClusterIds.Add("0");
                            startingResource = y;
                            break;
                        }
                        resourceClusterIds.Add(allResourceClusters[y].ClusterId);
                        shipCapacity -= allResourceClusters[y].NumberOfResources;
                    } else
                    {
                        resourceClusterIds.Add("0");
                        startingResource = y;
                        break;
                    }
                }
                output.Add(String.Join(",", resourceClusterIds.ToArray()));
            }

            return output.ToArray();
        }

        static string[] TraverseChunk(Simulation sim)
        {
            var ships = sim.ShipCount;
            var quotas = sim.Quotas.OrderBy(q => q.QuotaAmount).ToList();

            var allResourceClusters = new List<ResourceCluster>();
            foreach (var quota in quotas)
            {
                var subClusters = sim.Clusters
                     .Where(c => c.ResourceId == quota.ResourceId)
                     .OrderByDescending(c => c.NumberOfResources).ToList();
                allResourceClusters.AddRange(subClusters);
            }


            var totalClusters = allResourceClusters.Count;
            var clustersPerShip = (int)Math.Floor(decimal.Parse("" + (totalClusters / ships)));

            var resourceClusterChunks = Split(allResourceClusters.ToArray(), clustersPerShip).ToArray();

            List<string> output = new List<string>();

            for (var x = 0; x < ships; x++)
            {
                var shipCapacity = sim.ShipCapacity;
                var resourcesToExplore = resourceClusterChunks[x].ToArray<ResourceCluster>().OrderBy(c => c.DistanceFromCurrent).ToArray();
                List<string> resourceClusterIds = new List<string>();

                for (var y = 0; y < resourcesToExplore.Count(); y++)
                {
                    if (shipCapacity - resourcesToExplore[y].NumberOfResources > 0)
                    {
                        if (y == resourcesToExplore.Count() - 1)
                        {
                            resourceClusterIds.Add("0");
                            break;
                        }
                        resourceClusterIds.Add(resourcesToExplore[y].ClusterId);
                        shipCapacity -= resourcesToExplore[y].NumberOfResources;
                    }
                    else
                    {
                        resourceClusterIds.Add("0");
                        break;
                    }
                }
                output.Add(String.Join(",", resourceClusterIds.ToArray()));
            }

            return output.ToArray();
        }


        static string[] TraverseChunk2(Simulation sim)
        {
            var ships = sim.ShipCount;
            var quotas = sim.Quotas.OrderBy(q => q.QuotaAmount).ToList();

            var allResourceClusters = new List<ResourceCluster>();
            foreach (var quota in quotas)
            {
                var subClusters = sim.Clusters
                     .Where(c => c.ResourceId == quota.ResourceId)
                     .OrderByDescending(c => c.NumberOfResources).ToList();
                allResourceClusters.AddRange(subClusters);
            }


            var totalClusters = allResourceClusters.Count;
            var clustersPerShip = (int)Math.Floor(decimal.Parse("" + (totalClusters / ships)));

            var resourceClusterChunks = Split(allResourceClusters.ToArray(), clustersPerShip).ToArray();

            List<string> output = new List<string>();

            for (var x = 0; x < ships; x++)
            {
                var shipCapacity = sim.ShipCapacity;
                var resourcesToExplore = resourceClusterChunks[x].ToArray<ResourceCluster>().OrderBy(c => c.DistanceFromCenter).ToArray();
                List<string> resourceClusterIds = new List<string>();

                for (var y = 0; y < resourcesToExplore.Count(); y++)
                {
                    if (shipCapacity - resourcesToExplore[y].NumberOfResources > 0)
                    {
                        if (y == resourcesToExplore.Count() - 1)
                        {
                            resourceClusterIds.Add("0");
                            break;
                        }
                        resourceClusterIds.Add(resourcesToExplore[y].ClusterId);
                        shipCapacity -= resourcesToExplore[y].NumberOfResources;
                    }
                    else
                    {
                        resourceClusterIds.Add("0");
                        break;
                    }
                }
                output.Add(String.Join(",", resourceClusterIds.ToArray()));
            }

            return output.ToArray();
        }

        static IEnumerable<IEnumerable<ResourceCluster>> Split(this ResourceCluster[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
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

            simulation.ProcessQuotas(Resources);

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
