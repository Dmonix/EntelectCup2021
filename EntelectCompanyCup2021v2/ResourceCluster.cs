namespace EntelectCompanyCup2021v2
{
    public class ResourceCluster
    {
        public int ResourceId { get; }
        public string ClusterId { get; }
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public int NumberOfResources { get; }

        public ResourceCluster(int resourceId, string clusterId, int x, int y, int z, int numberOfResources)
        {
            ResourceId = resourceId;
            ClusterId = clusterId;
            X = x;
            Y = y;
            Z = z;
            NumberOfResources = numberOfResources;
        }

        public static ResourceCluster Create(string resourceId, string resourceData)
        {
            var data = resourceData.Split(',');
            return new ResourceCluster(int.Parse(resourceId), data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
        }
    }
}
