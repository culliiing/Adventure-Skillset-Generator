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

        List<Cell> cells;
        int width;
        int height;

        /// <summary>
        /// A matrix of Cells.
        /// </summary>
        /// <param name="width">Leave empty for random value.</param>
        /// <param name="height">Leave empty for random value.</param>
        public Grid(int height = 0, int width = 0)
        {
            cells = new List<Cell>();

            if (width < 1) 
                width = random.Next(1,10);
            if (height < 1) 
                height = random.Next(1,10);
            
            this.width = width;
            this.height = height;

            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    cells.Add(new Cell(i, j));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphic">Set to false if you want to see coordinates for each cell in the grid instead of a graphical representation.</param>
        public void Print(bool graphic = true)
        {
            Console.WriteLine("Grid");

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    CellWithCoordinates(i, j).Print(graphic);
                }

                Console.Write("\n");
            }
        }

        public void Place(Shape shape, int x, int y)
        {
            if (CellWithCoordinates(x, y).IsUnoccupied())
            {
                foreach (Cell cell in shape.GetCells())
                {
                    CellWithCoordinates(x + cell.GetCoordinate().X, y + cell.GetCoordinate().Y).SetSymbol(shape.ToString()[0]);
                }
            }
            else
                Debug.WriteLine($"Couldn't place shape {shape.ToString()} at ({x},{y}).");
        }

        public Cell CellWithCoordinates(int x, int y)
        {
            foreach (Cell cell in cells)
                if (cell.Overlaps(x, y))
                    return cell;

            return null;
        }
    }
}
