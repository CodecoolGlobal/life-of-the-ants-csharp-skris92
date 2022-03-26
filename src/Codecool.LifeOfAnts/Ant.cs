using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    abstract class Ant
    {
        public Position Position;
        protected Ant(int x, int y)
        {
            Position = new Position(x, y);
        }
        virtual public void Act(Ant[] area) { }
    }
}
