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
            if (actCooldown != 0) actCooldown--;
            else
            {
                int width = area.GetLength(0);
                int height = area.GetLength(1);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (area[i, j].GetType().Name == "Queen")
                        {
                            Queen queen = (Queen)area[i, j];
                            if (queen.IsInMood)
                            {
                                Mate();
                                queen.Mate();
                            }
                            else
                            {
                                KickOff(area);
                            }
                        }
                    }
                }
            }
        }
        private void Mate()
        {
            Console.WriteLine("HALLELUJAH");
            Console.ReadKey();
            actCooldown = 10;
        }
        private void KickOff(Ant[,] area)
        {
            Console.WriteLine(":(");
            Console.ReadKey();
            Random random = new Random();
            Direction randomDirection = (Direction)random.Next(0, 5);
        }
    }
}
