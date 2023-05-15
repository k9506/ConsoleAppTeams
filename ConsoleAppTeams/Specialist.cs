using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeams
{
    enum ESkill
    {
        CPP,
        CSharp,
        Java,
        JavaScript,
        Kotlin,
        Phyton,
        Developer,
        Backend,
        Frontend,
        TeamLead,
        Analitic,
        QualityAssurance,
    }

    internal class Specialist
    {
        public string Name { get; set; }

        public int Salary { get; set; }

        public List<ESkill> Skills { get; set; }

        public int Experience { get; set; }

        public bool HaveSkill(ESkill skill)
        {
            return Skills.Contains(skill);
        }

        public bool HaveExperience(int exp)
        {
            return Experience >= exp;
        }

        public override string ToString()
        {
            return
                $"Name: { this.Name }, " +
                $"Salary: { this.Salary }, " +
                $"Skills: [{ string.Join(", ", this.Skills) }], " +
                $"Exp: { this.Experience }";
        }
    }
}
