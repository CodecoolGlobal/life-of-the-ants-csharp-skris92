using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Queen : Ant
    {
        private bool isInMood;
        private int moodCooldown;
        public bool IsInMood => isInMood;
        public Queen(int x, int y) : base(x, y)
        {
            isInMood = true;
            moodCooldown = 0;
        }
        public void Mate()
        {
            isInMood = false;
            Random random = new Random();
            moodCooldown = random.Next(50,101);
        }
        public override void Act(Ant[,] area)
        {
            if (moodCooldown != 0) moodCooldown--;
            else isInMood = true;
        }
    }
}
