using System;
using System.Collections.Generic;
using System.Text;

namespace EntelectCompanyCup2021v2
{
    public class MapRow
    {
        public List<MapPoint> Points { get; } = new List<MapPoint>();
        public int RowNumber { get; }

        public MapRow(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        public void AddPoints(char[] points)
        {
            for (var x = 0; x < points.Length; x++)
            {
                var point = points[x];
                var y = RowNumber;
                Points.Add(new MapPoint(point, x, y));
            }
        }
        public short[] GenerateTraverseMap()
        {
            List<short> points = new List<short>();
            foreach(var point in Points)
            {
                points.Add((Int16)(point.CanTraverse ? 1 : 0));
            }

            return points.ToArray();
        }
    }
}
