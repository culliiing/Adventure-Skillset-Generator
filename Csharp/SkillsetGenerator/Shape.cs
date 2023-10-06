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
        char symbol;
        List<Cell> cells;

        /// <summary>
        /// Build your own Shape with manual instructions.
        /// </summary>
        /// <param name="instructions">Input string of directions where 8=up, 6=right, 2=down, 4=left.</param>
        public Shape(string name, string instructions)
        {
            this.name = name.ToUpper();
            this.symbol = this.name[0];
            this.cells = new List<Cell>() { new Cell(0,0,symbol) };
            this.Build(instructions);
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
            if (!Contains(x, y))
                throw new Exception("Cannot branch from non-existant Cell.");

            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case '6':
                        y++;
                        break;
                    case '4':
                        y--;
                        break;
                    case '8':
                        x--;
                        break;
                    case '2':
                        x++;
                        break;
                    default:
                        break;
                }

                if(!Contains(x,y))
                    cells.Add(new Cell(x,y,symbol));
            }
        }

        /// <summary>
        /// Checks whether a Cell with coordinates x and y (relative to the Shape's origin) exists within the Shape.
        /// </summary>
        public bool Contains(int x, int y)
        {
            foreach (Cell cell in cells)
                if(cell.Overlaps(x,y))
                    return true;

            return false;
        }

        /// <summary>
        /// Prints the coordinates of each Cell in the shape, relative to the shape.
        /// </summary>
        public void Print(bool graphic = true)
        {
            Console.Write($"{this.name}:");
            foreach (Cell cell in cells)
            {
                cell.Print(graphic);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
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