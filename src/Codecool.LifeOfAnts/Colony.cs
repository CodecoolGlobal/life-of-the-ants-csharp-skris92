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
        public Colony(int size)
        {
            area = new Ant[size, size];
            int centerIndex = (size % 2 == 0) ? size / 2 - 1 : size / 2;
            area[centerIndex, centerIndex] = new Queen(centerIndex, centerIndex);
        }
        public void Display()
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (area[i, j] == null) Console.Write("- ");
                    else Console.Write($"{area[i, j].ToString()} ");
                    if (j == area.GetLength(0) - 1) Console.WriteLine();
                }
            }
        }
        public void GenerateAnts(int drone, int soldier, int worker)
        {

        }
        public void Update()
        {

        }
    }
}
