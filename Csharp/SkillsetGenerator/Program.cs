using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            GetNewGrid().PrintEmpty();

            Console.ReadKey();
        }

        public static Grid GetNewGrid(int width = -1, int height = -1)
        {
            if (width < 1) width = random.Next(1, 10);
            if (height < 1) height = random.Next(1, 10);

            return new Grid(width, height);
        }
    }
}
