using System;
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

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.enabled = true;
        }

        public Cell(int x, int y, bool enabled) : this(x, y)
        {
            this.enabled = enabled;
        }
    }
}
