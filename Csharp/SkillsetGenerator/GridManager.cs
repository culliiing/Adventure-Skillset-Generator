﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class GridManager
    {
        Grid grid;
        Dictionary<Cell, Shape> cellToShapeMap;

        public GridManager(Grid grid)
        {
            this.grid = grid;
            cellToShapeMap = new Dictionary<Cell, Shape>();
        }

        public void AddShape(Shape shape, int x, int y)
        {
            bool shapeIsPlaceable = grid.ShapeFits(shape, x, y) && !ShapeOverlapsOccupiedCell(shape, x, y);
            bool shapeIsAllowed = shape.IsRepeatable() ? !IdenticalShapeIsOnGrid(shape) : !ShapeIsOnGrid(shape) && !IdenticalShapeIsOnGrid(shape);

            if(shapeIsAllowed && shapeIsPlaceable)
            {
                grid.PlaceShape(shape, x, y);
                AddShapeToMap(shape, x, y);

                if(Program.debug)
                    Console.WriteLine($"Placed {shape.ToString()} at ({x},{y})");
            }
        }

        void AddShapeToMap(Shape shape, int x, int y)
        {
            foreach (Cell cell in shape.GetCells())
            {
                int absoluteX = x + cell.X;
                int absoluteY = y + cell.Y;

                cellToShapeMap[new Cell(absoluteX, absoluteY)] = shape;
                //Console.WriteLine($"Adding ({absoluteX},{absoluteY}) to occupied cells list");
            }
        }

        /// <summary>
        /// Checks if the shape is already on the grid.
        /// </summary>
        public bool ShapeIsOnGrid(Shape shape)
        {
            List<Shape> shapesOnGrid = GetShapesOnGrid();

            if (shapesOnGrid.Contains(shape))
            {
                Console.WriteLine($"{shape.ToString()} is on the grid.");
                return true;
            }

            return false;
        }

        public bool IdenticalShapeIsOnGrid(Shape shape)
        {
            List<Shape> shapesOnGrid = GetShapesOnGrid();

            foreach (Shape other in shapesOnGrid)
            {
                if (shape.IsIdenticalToShape(other))
                {
                    Console.WriteLine($"{shape.ToString()}'s identical shape {other.ToString()} is on the grid.");
                    return true;
                }
            }

            return false;
        }

        public List<Shape> GetShapesOnGrid()
        {
            List<Shape> shapes = new List<Shape>();

            foreach (Shape shape in cellToShapeMap.Values)
                if(!shapes.Contains(shape))
                    shapes.Add(shape);

            return shapes;
        }

        public bool ShapeOverlapsOccupiedCell(Shape shape, int x, int y)
        {
            foreach (Cell cell in shape.GetCells())
            {
                int absoluteX = x + cell.X;
                int absoluteY = y + cell.Y;

                foreach (Cell placedCell in cellToShapeMap.Keys)
                {
                    //Console.WriteLine($"Comparing cell ({absoluteX}, {absoluteY}) to occupied cell ({placedCell.X},{placedCell.Y})");
                    if (placedCell.HasCoordinates(absoluteX, absoluteY))
                    {
                        Console.WriteLine($"{shape.ToString()}'s destination ({absoluteX},{absoluteY}) is occupied.");

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
