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

        public Grid(int width, int height)
        {
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
