using System;
using System.IO;
using 

namespace EntelectCompanyCup2021v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sim = ReadFile("input.txt");
        }

        static Simulation ReadFile(string inputFileName)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            // Generate sim
            var simInfo = lines[0].Split(','); // first line
            var simulation = Simulation.Create(simInfo);

            // Set map rows
            var mapIndex = 1;

            var map = new Map();

            for (int i = 0; i < simulation.MapHeight; i++)
            {
                var rowNumber = simulation.MapHeight - i;
                map.AddRow(lines[mapIndex + i], rowNumber);
            }

            simulation.Map = map;

            return simulation;
        }
    }
}
