using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Soldier : Ant
    {
        private Direction facing;
        public Soldier(int x, int y) : base (x, y)
        {
            Random random = new Random();
            facing = (Direction)random.Next(0,4);
        }
        public override void Act(Ant[,] area)
        {
            List<Position> AntPositions = GetAntPositionsList(area);

        }
    }
}
