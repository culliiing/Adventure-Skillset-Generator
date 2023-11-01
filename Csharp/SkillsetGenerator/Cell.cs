using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    public class Cell
    {
        Point coordinate;
        public int X { get { return coordinate.X; } set { coordinate.X = value; } }
        public int Y { get { return coordinate.Y; } set { coordinate.Y = value; } }
        char symbol;

        // Symbolizes cells that are not occupied
        const char alive = '|';

        public Cell(int x, int y, char symbol = alive)
        {
            this.coordinate.X = x;
            this.coordinate.Y = y;
            this.symbol = symbol;
        }

        public void Print(bool graphic = true)
        {
            string output = graphic ? symbol.ToString() : $"({X},{Y})";
            Console.Write(output);
        }

        public bool HasCoordinates(int x, int y)
        {
            if (coordinate.X == x && coordinate.Y == y)
                return true;

            return false;
        }

        public Cell Clone()
        {
            return new Cell(coordinate.X, coordinate.Y, symbol);
        }
    }
}
