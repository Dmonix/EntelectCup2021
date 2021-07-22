namespace EntelectCompanyCup2021v2
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PointsPerRawUnit { get; set; }
        public int PointsPerProcessedUnit { get; set; }
        public int ProcessingTime { get; set; }
        public decimal PointsPerTimeProcessed { get; set; }

        public Resource(int id, string name, int pointsPerRawUnit, int pointsPerProcessedUnit, int processingTime, decimal pointsPerTimeProcessed)
        {
            Id = id;
            Name = name;
            PointsPerRawUnit = pointsPerRawUnit;
            PointsPerProcessedUnit = pointsPerProcessedUnit;
            ProcessingTime = processingTime;
            PointsPerTimeProcessed = pointsPerTimeProcessed;
        }
    }
}