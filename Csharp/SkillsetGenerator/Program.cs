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

        static void Main(string[] args)
        {
            grid = new Grid();
            grid.Print();

            Console.ReadKey();
        }
    }
}
