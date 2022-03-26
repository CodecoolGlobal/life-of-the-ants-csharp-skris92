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
        private protected bool IsPositionOccupied(List<Position> AntPositions, Position NextPosition)
        {
            bool isOccupied = false;
            foreach (Position antPositon in AntPositions)
            {
                if (antPositon.X == NextPosition.X && antPositon.Y == NextPosition.Y)
                {
                    isOccupied = true;
                    break;
                }
            }
            return isOccupied;
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
