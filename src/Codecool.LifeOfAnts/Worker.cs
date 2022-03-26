using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Worker : Ant
    {
        public Worker(int x, int y) : base (x, y)
        {

        }
        public override void Act()
        {
            Random random = new Random();
            Direction randomDrection = (Direction)random.Next(0, 5);
        }
    }
}
