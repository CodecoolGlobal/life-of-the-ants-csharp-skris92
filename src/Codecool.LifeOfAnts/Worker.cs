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
        public override void Act(Ant[,] area)
        {
            List<Position> AntPositions = GetAntPositionsList(area);
            Position NextPosition = GenerateNextPosition(area);
            if (!IsPositionOccupied(AntPositions, NextPosition))
            {
                Position = new Position(NextPosition.X, NextPosition.Y);
            }
        }
        private Position GenerateNextPosition(Ant[,] area)
        {
            Random random = new Random();
            Direction direction = (Direction)random.Next(0, 4);

            if (direction == Direction.North && this.Position.X > 0)
            {
                return new Position(this.Position.X - 1, this.Position.Y);
            }
            else if (direction == Direction.South && this.Position.X < area.GetLength(1) - 1)
            {
                return new Position(this.Position.X + 1, this.Position.Y);
            }
            else if (direction == Direction.West && this.Position.Y > 0)
            {
                return new Position(this.Position.X, this.Position.Y - 1);
            }
            else if (direction == Direction.East && this.Position.Y < area.GetLength(0) - 1)
            {
                return new Position(this.Position.X, this.Position.Y + 1);
            }
            else
            {
                return new Position(this.Position.X, this.Position.Y);
            }
        }
    }
}
