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
        public virtual void Act(Ant[,] area) { }
        private protected List<Position> GetAntPositionsList(Ant[,] area)
        {
            List<Position> positions = new();
            foreach (Ant ant in area)
            {
                if (ant != null) positions.Add(new Position(ant.Position.X, ant.Position.Y));
            }
            return positions;
        }
        public override string ToString()
        {
            switch (this.GetType().Name)
            {
                case "Queen":
                    return "Q";
                case "Drone":
                    return "D";
                case "Soldier":
                    return "S";
                case "Worker":
                    return "W";
                default:
                    return "Can't identify Ant!";
            }
        }
    }
}
