using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    internal class Skill
    {
        string name;
        bool repeatable;

        public Skill(string name, bool repeatable = false)
        {
            this.name = name;
            this.repeatable = repeatable;
        }
    }
}
