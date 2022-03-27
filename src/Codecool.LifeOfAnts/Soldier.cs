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
            Position NextPosition = GenerateNextPosition(area);
            if (!IsPositionOccupied(AntPositions, NextPosition))
            {
                Position = NextPosition;
            }
        }
        private Position GenerateNextPosition(Ant[,] area)
        {
            switch (facing)
            {
                case Direction.North:
                    facing += 1;
                    if (this.Position.X > 0)
                    {
                        return new Position(this.Position.X - 1, this.Position.Y);
                    }
                    break;
                case Direction.South:
                    facing += 1;
                    if (this.Position.X < area.GetLength(1) - 1)
                    {
                        return new Position(this.Position.X + 1, this.Position.Y);
                    }
                    break;
                case Direction.West:
                    facing += 1;
                    if (this.Position.Y > 0)
                    {
                        return new Position(this.Position.X, this.Position.Y - 1);
                    }
                    break;
                case Direction.East:
                    facing = Direction.North;
                    if (this.Position.Y < area.GetLength(0) - 1)
                    {
                        return new Position(this.Position.X, this.Position.Y + 1);
                    }
                    break;
            }
            return new Position(this.Position.X, this.Position.Y);
        }
    }
}
