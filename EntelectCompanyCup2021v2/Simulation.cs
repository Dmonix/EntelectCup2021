using System;
using System.Collections.Generic;
using System.Text;

namespace EntelectCompanyCup2021v2
{
    class Simulation
    {
        public int SpaceshipCount { get; }
        public int CrateCount { get; }
        public int BaseCount { get; }
        public int MapWidth { get; }
        public int MapHeight { get; }

        public Map Map { get; set; }

        public Simulation(int spaceshipCount, int crateCount, int baseCount, int mapWidth, int mapHeight)
        {
            SpaceshipCount = spaceshipCount;
            CrateCount = crateCount;
            BaseCount = baseCount;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
        }
        public static Simulation Create(string[] values)
        {
            return new Simulation(int.Parse(values[0]),
                int.Parse(values[1]),
                int.Parse(values[2]),
                int.Parse(values[3]),
                int.Parse(values[4]));
        }
    }
}
