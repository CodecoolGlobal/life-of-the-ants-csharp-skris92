using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public abstract class Ant
    {
        public Position Position;
        public Ant(int x, int y)
        {
            Position = new Position(x, y);
        }
        public virtual void Act() { }
        public virtual void Act(Ant[,] area) { }
    }
}
