using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Program
    {
        static Random random = new Random();
        Grid grid;

        static void Main(string[] args)
        {
            Grid grid = GetNewGrid();
            grid.PrintEmpty();

            Console.ReadKey();
        }

        public static Grid GetNewGrid()
        {

            int height = 5;
            int width = 4;

            return new Grid(width, height);
        }
    }
}
