using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Shape
    {
        string name;
        List<Cell> cells;
        char symbol;
        public char Symbol { get { return symbol; } }

        /// <summary>
        /// Build your own Shape with manual instructions.
        /// </summary>
        /// <param name="instructions">Input string of directions where 8=up, 6=right, 2=down, 4=left.</param>
        public Shape(string name, string instructions)
        {
            this.name = name.ToUpper();
            this.symbol = this.name[0];
            this.cells = new List<Cell>() { new Cell(0,0,this) };
            this.Build(instructions);

            if (Program.debug)
                Print();
        }

        public Shape(string name, List<Cell> cells)
        {
            this.name = name.ToUpper();
            this.symbol = this.name[0];
            this.cells = cells;
        }

        /// <summary>
        /// Adds Cells to a Shape in a tree-like or branching fashion based on inputted directions.
        /// </summary>
        /// <param name="instructions">Input string of directions where 8=up, 6=right, 2=down, 4=left.</param>
        /// <param name="x">Enter the x coordinate from where the Shape will begin to expand. Must be from within the Shape.</param>
        /// <param name="y">Enter the y coordinate from where the Shape will begin to expand. Must be from within the Shape.</param>
        public void Build(string instructions, int x = 0, int y = 0)
        {
            if (!ContainsCell(x, y))
                throw new Exception("Cannot branch from non-existant Cell.");

            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions.ToUpper()[i])
                {
                    case '8':
                    case 'W':
                        x--;
                        break;

                    case '4':
                    case 'A':
                        y--;
                        break;

                    case '2':
                    case 'S':
                        x++;
                        break;

                    case 'D':
                    case '6':
                        y++;
                        break;

                    default:
                        break;
                }

                if(!ContainsCell(x,y))
                    cells.Add(new Cell(x,y,this));
            }
        }

        /// <summary>
        /// Checks whether a Cell with coordinates x and y (relative to the Shape's origin) exists within the Shape.
        /// </summary>
        public bool ContainsCell(int x, int y)
        {
            foreach (Cell cell in cells)
                if(cell.HasCoordinates(x,y))
                    return true;

            return false;
        }

        public bool IsIdenticalToShape(Shape other)
        {
            return true;
        }

        public void Rotate90()
        {
            foreach (Cell cell in cells)
            {
                int oldX = cell.X;
                cell.X = cell.Y;
                cell.Y = -oldX;
            }
        }

        public void ReflectVertical()
        {
            foreach (Cell cell in cells)
            {
                cell.X = -cell.X;
            }
        }

        public void ReflectHorizontal()
        {
            foreach (Cell cell in cells)
            {
                cell.Y = -cell.Y;
            }
        }

        /// <summary>
        /// Prints the coordinates of each Cell in the shape, relative to the shape.
        /// </summary>
        public void Print(bool graphic = false)
        {
            Console.Write($"{this.name}: ");

            if (!graphic)
            {
                foreach (Cell cell in cells)
                {
                    cell.Print(graphic);
                }
            }
            else
            {
                // Find the dimensions of the grid
                int maxX = cells.Max(cell => cell.X);
                int minX = cells.Min(cell => cell.X);
                int maxY = cells.Max(cell => cell.Y);
                int minY = cells.Min(cell => cell.Y);

                int height = maxX - minX;
                int width = maxY - minY;

                // Get the greatest length of the shape
                int maxLength = height > width ? height + 1 : width + 1;

                // Create a grid and place the shape in the center of it
                Grid grid = new Grid(maxLength*2-1, maxLength*2-1);
                grid.PlaceShape(this, maxLength-1, maxLength-1);

                // Print the grid
                Console.Write($"\n");
                grid.Print();
            }

            Console.WriteLine();
        }

        /// <returns>Name of the Shape.</returns>
        public override string ToString()
        {
            return name;
        }

        public List<Cell> GetCells()
        {
            return cells;
        }
    }
}