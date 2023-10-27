using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetGenerator
{
    /// <summary>
    /// 
    /// </summary>
    /// <!---->
    public enum RelationType
    {
        Exclusive,
        Impossible
    }

    internal class Relation
    {
        List<Skill> skills;
        List<Skill> others;

        RelationType type;

        public Relation(List<Skill> skills, RelationType type) 
        {
            this.skills = skills;
            this.type = type;
        }

        public Relation(Skill skill, Skill other, RelationType type)
        {
            skills.Add(skill);
            others.Add(other);
            this.type = type;
        }

        public Relation(List<Skill> skills, Skill other, RelationType type) : this(skills, type)
        {
            others.Add(other);
        }

        public Relation(List<Skill> skills, List<Skill> others, RelationType type): this(skills, type)
        {
            this.others = others;
        }

    }
}
