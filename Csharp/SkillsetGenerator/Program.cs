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
            grid = new Grid();
            grid.Print();
            Shape A = new Shape("Abraham", "d");
            Shape B = new Shape("Beatrice", "ds");
            Shape C = new Shape("Catherine", "dsaw");
            Shape D = new Shape("Diane", "s");
            grid.PlaceShape(A, 2, 0);
            grid.Print();
            grid.PlaceShape(D, 0, 1);
            grid.Print();
            grid.PlaceShape(C, 0, 0);
            grid.Print();

            Console.ReadKey();
        }
    }
}
