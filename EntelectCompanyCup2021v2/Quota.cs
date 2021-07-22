namespace EntelectCompanyCup2021v2
{
    public class Quota
    {
        public int ResourceId { get; }
        public int QuotaAmount { get; }

        public Quota(int resourceId, int quotaAmount)
        {
            ResourceId = resourceId;
            QuotaAmount = quotaAmount;
        }

        public static Quota Create(string line)
        {
            var data = line.Split('|');
            return new Quota(int.Parse(data[0]), int.Parse(data[1]));
        }
    }
}
