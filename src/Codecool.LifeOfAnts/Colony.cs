using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        private Ant[,] area;
        public Colony(int width)
        {
            area = new Ant[width, width];
            int centerIndex = (width % 2 == 0) ? width / 2 - 1 : width / 2;
            area[centerIndex, centerIndex] = new Queen(centerIndex, centerIndex);
        }
        public void Display()
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (area[i, j] == null) Console.Write("- ");
                    else Console.Write(area[i, j].ToString() + " ");
                    if (j == area.GetLength(0) - 1) Console.WriteLine();
                }
            }
        }
        public void GenerateAnts(int drones, int soldiers, int workers)
        {
            GenerateUnitsOfType(drones, "Drone");
            GenerateUnitsOfType(soldiers, "Soldier");
            GenerateUnitsOfType(workers, "Worker");
        }
        private void GenerateUnitsOfType(int numberOfUnits, string type)
        {
            for (int i = 0; i < numberOfUnits; i++)
            {
                (int, int) randomCoords = GetValidPositionCoords();
                switch (type)
                {
                    case "Drone":
                        area[randomCoords.Item1, randomCoords.Item2] = new Drone(randomCoords.Item1, randomCoords.Item2);
                        break;
                    case "Soldier":
                        area[randomCoords.Item1, randomCoords.Item2] = new Soldier(randomCoords.Item1, randomCoords.Item2);
                        break;
                    case "Worker":
                        area[randomCoords.Item1, randomCoords.Item2] = new Worker(randomCoords.Item1, randomCoords.Item2);
                        break;
                    default:
                        throw new Exception("Not valid type. Valid types: \"Drone\", \"Soldier\", \"Worker\"");
                }
            }
        }
        private (int, int) GetValidPositionCoords()
        {
            Random random = new Random();
            (int, int) randomCoords;
            do
            {
                randomCoords.Item1 = random.Next(area.GetLength(0));
                randomCoords.Item2 = random.Next(area.GetLength(1));
            }
            while (area[randomCoords.Item1, randomCoords.Item2] != null);
            return randomCoords;
        }
        public void Update()
        {
            foreach (Ant ant in area)
            {
                if (ant != null) ant.Act(area);
            }
            UpdateArea();
        }
        private void UpdateArea()
        {
            Ant[,] newArea = new Ant[area.GetLength(0), area.GetLength(1)];
            foreach (Ant ant in area)
            {
                if (ant != null) newArea[ant.Position.X, ant.Position.Y] = ant;
            }
            area = newArea;
        }
    }
}
