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

        /// <param name="force">Replaces existing shapes and overrides disabled grid cells. May cause out-of-bounds errors if true.</param>
        public void PlaceShape(Shape shape, int x, int y, bool force = false)
        {
            if (ShapeFits(shape, x, y) || force)
            {
                foreach (Cell cell in shape.GetCells())
                {
                    cells[x + cell.X, y + cell.Y] = cell;
                }

                if(Program.debug)
                    Console.WriteLine($"Shape {shape.ToString()} placed at ({x},{y}).");
            }
            else if(Program.debug)
                Console.WriteLine($"Could not place shape {shape.ToString()} at ({x},{y}).");
        }

        public bool ShapeFits(Shape shape, int x, int y)
        {
            foreach (Cell cell in shape.GetCells())
            {
                int absoluteX = x + cell.X;
                int absoluteY = y + cell.Y;

                if (absoluteX > height-1 || absoluteX < 0)
                    return false;

                if (absoluteY > width-1 || absoluteY < 0)
                    return false;

                if (!cells[absoluteX,absoluteY].IsAvailable())
                    return false;
            }

            return true;
        }
    }
}
