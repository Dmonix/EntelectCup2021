using System;
using System.Collections.Generic;
using System.Text;

namespace EntelectCompanyCup2021v2
{
    public class Map
    {
        public List<MapRow> Rows { get; } = new List<MapRow>();

        public void AddRow(string row, int rowNumber)
        {
            var mapRow = new MapRow(rowNumber);

            var rowPoints = row.ToCharArray();
            mapRow.AddPoints(rowPoints);
            Rows.Add(mapRow);
        }

        public short[][] GenerateTraverseMap()
        {
            List<short[]> rows = new List<short[]>();
            foreach (var row in Rows)
            {
                rows.Add(row.GenerateTraverseMap());
            }

            return rows.ToArray();
        }
    }
}
