using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Drone : Ant
    {
        private int actCooldown;
        public Drone(int x, int y) : base(x, y)
        {
            actCooldown = 0;
        }
        public override void Act(Ant[,] area)
        {
            if (actCooldown > 1) actCooldown--;
            else if (actCooldown == 1)
            {
                ResetPosition(area);
                actCooldown--;
            }
            else
            {
                List<Position> AntPositions = GetAntPositionsList(area);
                Position QueenPosition = GetQueenPosition(area);
                Position NextPosition = GetPositionTowardsQueen(area, QueenPosition);
                Queen Queen = (Queen)area[QueenPosition.X, QueenPosition.Y];

                if (!IsPositionOccupied(AntPositions, NextPosition))
                {
                    this.Position = NextPosition;
                }
                else if (area[NextPosition.X, NextPosition.Y] == Queen)
                {
                    if (Queen.IsInMood)
                    {
                        Mate();
                        Queen.Mate();
                    }
                    else
                    {
                        Console.WriteLine(":(");
                        Console.ReadKey();
                        ResetPosition(area);
                    }
                }
            }
        }
        private Position GetQueenPosition(Ant[,] area)
        {
            int queenPosition;
            if (area.GetLength(0) % 2 == 0) queenPosition = area.GetLength(0) / 2 - 1;
            else queenPosition = area.GetLength(0) / 2;
            return new Position(queenPosition, queenPosition);
        }
        private Position GetPositionTowardsQueen(Ant[,] area, Position QueenPosition)
        {
            int XDistanceFromQueen = Math.Abs(QueenPosition.X - this.Position.X);
            int YDistanceFromQueen = Math.Abs(QueenPosition.Y - this.Position.Y);

            if (XDistanceFromQueen > YDistanceFromQueen)
            {
                if (this.Position.X < QueenPosition.X) return new Position(this.Position.X + 1, this.Position.Y);
                else return new Position(this.Position.X - 1, this.Position.Y);
            }
            else if (XDistanceFromQueen < YDistanceFromQueen)
            {
                if (this.Position.Y < QueenPosition.Y) return new Position(this.Position.X, this.Position.Y + 1);
                else return new Position(this.Position.X, this.Position.Y - 1);
            }
            else
            {
                Random random = new Random();
                int randomChoice = random.Next(0, 2);
                if (this.Position.X < QueenPosition.X && this.Position.Y < QueenPosition.Y)
                {
                    if (randomChoice == 0) return new Position(this.Position.X + 1, this.Position.Y);
                    else return new Position(this.Position.X, this.Position.Y + 1);
                }
                else if (this.Position.X < QueenPosition.X && this.Position.Y > QueenPosition.Y)
                {
                    if (randomChoice == 0) return new Position(this.Position.X + 1, this.Position.Y);
                    else return new Position(this.Position.X, this.Position.Y - 1);
                }
                else if (this.Position.X > QueenPosition.X && this.Position.Y > QueenPosition.Y)
                {
                    if (randomChoice == 0) return new Position(this.Position.X - 1, this.Position.Y);
                    else return new Position(this.Position.X, this.Position.Y - 1);
                }
                else
                {
                    if (randomChoice == 0) return new Position(this.Position.X - 1, this.Position.Y);
                    else return new Position(this.Position.X, this.Position.Y + 1);
                }
            }
        }
        private void Mate()
        {
            Console.WriteLine("HALLELUJAH");
            Console.ReadKey();
            actCooldown = 10;
        }
        private void ResetPosition(Ant[,] area)
        {
            Random random = new Random();
            List<Position> AntPositions = GetAntPositionsList(area);
            Position NextPosition;
            Direction randomDirection = (Direction)random.Next(0, 4);

            do
            {
                int randomCoord = random.Next(0, area.GetLength(0));
                switch (randomDirection)
                {
                    case Direction.North:
                        NextPosition = new Position(0, randomCoord);
                        break;
                    case Direction.West:
                        NextPosition = new Position(randomCoord, 0);
                        break;
                    case Direction.South:
                        NextPosition = new Position(area.GetLength(0) - 1, randomCoord);
                        break;
                    case Direction.East:
                        NextPosition = new Position(randomCoord, area.GetLength(0) - 1);
                        break;
                    default:
                        NextPosition = Position;
                        break;
                }
            }
            while (IsPositionOccupied(AntPositions, NextPosition));
            Position = NextPosition;
        }
    }
}
