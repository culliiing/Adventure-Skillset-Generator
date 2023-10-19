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
        static Grid grid;
        public static bool debug = true;

        static void Main(string[] args)
        {
            grid = new Grid(10,10);
            grid.Print();
            Shape A = new Shape("Abraham", "d");
            Shape B = new Shape("Beatrice", "ds");
            Shape C = new Shape("Catherine", "dsa");
            Shape D = new Shape("Diane", "s");

            B.Print(true);
            B.Rotate90().ReflectVertical().Rotate90().Print(true);

            Console.ReadKey();
        }
    }
}
