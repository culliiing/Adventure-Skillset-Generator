using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    public interface IGrid
    {
        void PlaceShape(Shape shape, int x, int y);
        bool ShapeFits(Shape shape, int x, int y);
    }

    internal class Program
    {
        public static bool debug = true;
        public static Random random = new Random();
        
        static Grid grid;

        static Shape A;
        static Shape B;
        static Shape C;
        static Shape D;
        static Shape E;
        static Shape F;
        static Shape G;
        static GridManager gridManager;

        static void Main(string[] args)
        {
            InitializeGrids();
            InitializeShapes();
            InitializeSkills();

            grid = new Grid();
            gridManager = new GridManager(grid);
            
            //PlaceShapes();
            //SimpleShapeComparisonTest();
            //ShapeComparisonTest();

            Console.ReadKey();
        }

        static void InitializeGrids()
        {
            grid = new Grid();
            //grid.Print();
        }

        static void InitializeShapes()
        {
            A = new Shape("Abraham", "d");
            B = new Shape("Beatrice", "ds");
            C = new Shape("Catherine", "dsa");
            D = new Shape("Diane", "s");
            E = new Shape("Ernest", "sdwddsdassaaawasaasadsdsdds");
            G = new Shape("George", "dd");
            //F = new Shape("Emingway", "waasawsdwddsdassaaawasaasadsdsdds");
        }

        static void InitializeSkills()
        {
            Skill lightArmour = new Skill("Light Armour");
        }

        static void SimpleShapeComparisonTest()
        {
            A.Print(true);
            D.Print(true);
            Console.WriteLine($"Shapes are identical: {A.IsIdenticalToShape(D)} \n");
            A.Print(true);
            D.Print(true);
        }

        static void ShapeComparisonTest()
        {
            F = E.Clone();
            F.Rotate90().Rotate90().ReflectHorizontal().ShiftOriginToCell(F.GetCells()[random.Next(F.GetCells().Count())]);
            E.Print(true);
            F.Print(true);
            Console.WriteLine($"Shapes are identical: {E.IsIdenticalToShape(F)} \n");
            E.Print(true);
            F.Print(true);
        }

        static void PlaceShapes()
        {
            gridManager.AddShape(A, 0, 0);
            gridManager.AddShape(B, 1, 0);
            gridManager.AddShape(A, 0, 1);
            gridManager.AddShape(D, 3, 0);
            gridManager.AddShape(C, 3, 0);
            gridManager.AddShape(G, 2, 0);
            grid.Print();
        }
    }
}
