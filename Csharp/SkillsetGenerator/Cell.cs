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
        int x;
        int y;
        bool enabled;
        char symbol;

        // Symbolizes cells that are not occupied
        const char alive = 'O';
        // Symbolizes cells that cannot be occupied
        const char dead = 'X';

        Point coordinate;

        public Cell(int x, int y, bool enabled = true)
        {
            this.x = x;
            this.y = y;
            this.coordinate = new Point(x, y);
            this.enabled = enabled;
            this.symbol = enabled ? alive : dead;
        }

        public Cell(int x, int y, char symbol) : this(x,y)
        {
            this.symbol = symbol;
        }

        public Cell(Point coordinate, bool enabled = true)
        {
            this.x = coordinate.X;
            this.y = coordinate.Y;
            this.coordinate = coordinate;
            this.enabled = enabled;
            this.symbol = enabled ? alive : dead;
        }

        public Cell(Point coordinate, char symbol) : this(coordinate)
        {
            this.symbol = symbol;
        }

        public void Print(bool graphic = true)
        {
            string output = graphic ? symbol.ToString() : $"({coordinate.X},{coordinate.Y})";
            Console.Write(output);

            //if (graphic)
            //    Console.Write(symbol);
            //else
            //    Console.Write($"({coordinate.X},{coordinate.Y})");
        }

        public bool Overlaps(int x, int y)
        {
            if (this.x == x && this.y == y)
                return true;
            return false;
        }

        public bool IsUnoccupied()
        {
            if(symbol == alive && enabled) return true;
            return false;
        }

        public Point GetCoordinate()
        {
            return coordinate;
        }

        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }
    }
}
