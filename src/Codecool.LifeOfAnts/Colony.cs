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
            int center = Convert.ToInt32(Math.Round(Convert.ToDouble(size) / 2));
            area[center, center] = new Queen(center, center);
        }
        public void Display()
        {

        }
        public void GenerateAnts(int drone, int soldier, int worker)
        {

        }
        public void Update()
        {

        }
    }
}
