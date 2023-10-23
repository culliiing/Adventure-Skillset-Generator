using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Cell
    {
        Point coordinate;
        public int X { get { return coordinate.X; } set { coordinate.X = value; } }
        public int Y { get { return coordinate.Y; } set { coordinate.Y = value; } }

        bool enabled;
        char symbol;
        Shape shape;

        // Symbolizes cells that are not occupied
        const char alive = '|';
        // Symbolizes cells that cannot be occupied
        const char dead = 'X';

        public Cell(int x, int y, bool enabled = true)
        {
            this.coordinate = new Point(x, y);
            this.enabled = enabled;
            this.symbol = enabled ? alive : dead;
        }

        public Cell(int x, int y, Shape shape) : this(x,y)
        {
            this.shape = shape;
            this.symbol = shape.Symbol;
        }

        public void Print(bool graphic = true)
        {
            string output = graphic ? symbol.ToString() : $"({coordinate.X},{coordinate.Y})";
            Console.Write(output);
        }

        public bool HasCoordinates(int x, int y)
        {
            if (coordinate.X == x && coordinate.Y == y)
                return true;

            return false;
        }

        public bool IsAvailable()
        {
            if (!enabled)
                return false;

            if (shape != null)
                return false;

            return true;
        }

        // A method for cloning a Cell
        public Cell Clone()
        {
            return new Cell(this.X, this.Y, this.shape);
        }
    }
}
