namespace EntelectCompanyCup2021v2
{
    public class Resource
    {
        public int Id { get; }
        public string Name { get; }
        public int PointsPerRawUnit { get; }
        public int PointsPerProcessedUnit { get; }
        public int ProcessingTime { get; }
        public decimal PointsPerTimeProcessed { get; }
        public decimal PriorityScore { get; private set; }
        public decimal Quota { get; private set; }

        public Resource(int id, string name, int pointsPerRawUnit, int pointsPerProcessedUnit, int processingTime, decimal pointsPerTimeProcessed)
        {
            Id = id;
            Name = name;
            PointsPerRawUnit = pointsPerRawUnit;
            PointsPerProcessedUnit = pointsPerProcessedUnit;
            ProcessingTime = processingTime;
            PointsPerTimeProcessed = pointsPerTimeProcessed;
        }

        public void SetResourceQuota(decimal quota)
        {
            Quota = quota;
            PriorityScore = PointsPerTimeProcessed * (Quota / 100m);
        }
    }
}