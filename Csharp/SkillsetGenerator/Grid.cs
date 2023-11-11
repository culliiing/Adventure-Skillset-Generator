using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Grid
    {
        Random random = new Random();

        Cell[,] cells;
        List<Cell> disabledCells;
        int width;
        int height;

        /// <summary>
        /// A matrix of Cells.
        /// </summary>
        /// <param name="width">Leave empty for random value.</param>
        /// <param name="height">Leave empty for random value.</param>
        public Grid(int height = 0, int width = 0)
        {
            if (width < 1) 
                width = random.Next(1,10);
            if (height < 1) 
                height = random.Next(1,10);

            this.cells = new Cell[height, width];
            this.disabledCells = new List<Cell>();
            this.width = width;
            this.height = height;

            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }            
        }

        /// <param name="graphic">Set to false if you want to see coordinates for each cell in the grid instead of a graphical representation.</param>
        public void Print(bool graphic = true)
        {
            Console.WriteLine("Grid");

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j].Print(graphic);
                }
                
                Console.WriteLine(); // first row done, line-break
            }
        }

        public void PlaceShape(Shape shape, int x, int y)
        {
            foreach (Cell cell in shape.GetCells())
            {
                cells[x + cell.X, y + cell.Y] = cell;
            }
        }

        public bool ShapeFits(Shape shape, int x, int y)
        {
            // Check if shape is out of bounds or on top of another shape
            foreach (Cell cell in shape.GetCells())
            {
                int absoluteX = x + cell.X;
                int absoluteY = y + cell.Y;

                if (IsOutOfBounds(absoluteX, absoluteY))
                {
                    if (Program.debug)
                        Console.WriteLine($"Could not place {shape.ToString()} out of bounds at ({x},{y}).");

                    return false;
                }

                if (CellIsDisabled(absoluteX, absoluteY))
                {
                    if (Program.debug)
                        Console.WriteLine($"Could not place {shape.ToString()} on disabled cell ({x},{y})");

                    return false;
                }
            }

            return true;
        }

        // Check if coordinates is out of bounds of the grid
        public bool IsOutOfBounds(int x, int y)
        {
            if (x > height - 1 || x < 0 || y > width - 1 || y < 0)
                return true;

            return false;
        }

        public bool CellIsDisabled(int x, int y)
        {
            foreach(Cell cell in disabledCells)
                if(cell.HasCoordinates(x,y))
                    return true;

            return false;
        }

        void DisableCell(Cell cell)
        {
            cell = new Cell(cell.X, cell.Y, 'X');
            disabledCells.Add(cell);
        }
    }
}
