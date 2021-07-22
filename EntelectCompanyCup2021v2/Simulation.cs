using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntelectCompanyCup2021v2
{
    class Simulation
    {
        public int WidthX { get; }
        public int HeightY { get; }
        public int DepthZ { get; }

        public int UniqueResources { get; }
        public int ShipCapacity { get; }
        public int LabCount { get; }
        public int OutpostMaterialThreshold { get; }
        public int QuotaCount { get; }

        public List<Ship> Ships { get; } = new List<Ship>();

        public List<Quota> Quotas { get; set; } = new List<Quota>();
        public List<ResourceCluster> Clusters { get; set; } = new List<ResourceCluster>();
        public List<Resource> SimulationResources = new List<Resource>();

        public Simulation(int widthX, int heightY, int depthZ, int uniqueResources, int shipCount, int shipCapacity, int labCount, int outpostMaterialThreshold, int quotaCount)
        {
            WidthX = widthX;
            HeightY = heightY;
            DepthZ = depthZ;
            UniqueResources = uniqueResources;
            ShipCapacity = shipCapacity;
            LabCount = labCount;
            OutpostMaterialThreshold = outpostMaterialThreshold;
            QuotaCount = quotaCount;

            for (int i = 0; i < shipCount; i++)
            {
                Ships.Add(new Ship(i, shipCapacity));
            }
        }

        public static Simulation Create(string inputLine)
        {
            var items = inputLine.Split('|');
            var coOrds = items[0].Split(',');

            return new Simulation(int.Parse(coOrds[0]), int.Parse(coOrds[1]), int.Parse(coOrds[2]), 
                int.Parse(items[1]), int.Parse(items[2]), int.Parse(items[3]), int.Parse(items[4]), int.Parse(items[5]), int.Parse(items[6]));
        }

        public void ProcessQuotas(List<Resource> resources)
        {
            for(int i = 0; i < Quotas.Count; i++)
            {
                SimulationResources.Add(resources.SingleOrDefault(r => r.Id == Quotas[i].ResourceId));
                SimulationResources[i].SetResourceQuota(Quotas[i].QuotaAmount);
            }
        }
    }
}