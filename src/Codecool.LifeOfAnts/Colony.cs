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
            area[size / 2, size / 2] = new Queen(size / 2, size / 2);
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
