using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Grid
    {
        Random random = new Random();

        int[,] grid;

        string empty = "_";
        string dead = "X";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Leave empty for random value.</param>
        /// <param name="height">Leave empty for random value.</param>
        public Grid(int width = 0, int height = 0)
        {
            if (width < 1)
                width = random.Next(1,10);
            if (height < 1)
                height = random.Next(1,10);

            this.grid = new int[width, height];
        }

        public void PrintEmpty()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(empty);
                }
                Console.WriteLine("");
            }
        }
    }
}
