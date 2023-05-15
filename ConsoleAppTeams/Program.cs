namespace ConsoleAppTeams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var specialistes = new List<Specialist>();
            specialistes.Add(new Specialist {
                Name = "Вася",
                Salary = 120000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Backend, ESkill.CSharp },
                Experience = 3,
            });
            specialistes.Add(new Specialist {
                Name = "Петя",
                Salary = 200000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Backend, ESkill.CSharp },
                Experience = 5,
            });
            specialistes.Add(new Specialist {
                Name = "Степан",
                Salary = 140000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Backend, ESkill.Java },
                Experience = 3,
            });
            specialistes.Add(new Specialist {
                Name = "Артём",
                Salary = 200000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Backend, ESkill.Java },
                Experience = 5,
            });
            specialistes.Add(new Specialist {
                Name = "Ваня",
                Salary = 120000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Frontend, ESkill.JavaScript },
                Experience = 3,
            });
            specialistes.Add(new Specialist {
                Name = "Гоша",
                Salary = 100000,
                Skills = new List<ESkill> { ESkill.Developer, ESkill.Frontend, ESkill.JavaScript },
                Experience = 2,
            });
            specialistes.Add(new Specialist {
                Name = "Анатолий",
                Salary = 100000,
                Skills = new List<ESkill> { ESkill.TeamLead },
                Experience = 2,
            });
            specialistes.Add(new Specialist
            {
                Name = "Саша",
                Salary = 100000,
                Skills = new List<ESkill> { ESkill.QualityAssurance },
                Experience = 2,
            });

            specialistes.Sort((a, b) => (a.Salary / a.Experience) - (b.Salary / b.Experience));

            var skillValues = Enum.GetValues(typeof(ESkill));

            Console.Write("Type team count: ");
            int teamCount = Convert.ToInt16(Console.ReadLine());
            var teamSkills = new List<int>();
            Console.WriteLine();

            Console.WriteLine("Available skills:");
            foreach (int i in skillValues) Console.WriteLine($"{i} - { Enum.GetName(typeof(ESkill), i) }");

            Console.WriteLine();
            for (int i = 0; i < teamCount; i++)
            {
                Console.Write($"Type skill index for specialist #{i}: ");
                teamSkills.Add(Convert.ToInt16(Console.ReadLine()));
            }

            var foundSpecialistes = new List<Specialist>();
            teamSkills.ForEach((skill) => {
                var foundIndex = specialistes.FindIndex((spec) => spec.Skills.Contains((ESkill)skill));
                if (foundIndex != -1) {
                    foundSpecialistes.Add(specialistes[foundIndex]);
                    specialistes.RemoveAt(foundIndex);
                }
            });

            Console.WriteLine();
            Console.WriteLine("Found:");
            foundSpecialistes.ForEach((spec) => Console.WriteLine(spec));
            Console.WriteLine("About team:");
            Console.WriteLine($"Team selary: {foundSpecialistes.Aggregate(0, (acc, el) => acc + el.Salary)}");
            Console.WriteLine($"Average team experience: " +
                $"{foundSpecialistes.Aggregate(0, (acc, el) => acc + el.Experience) / (float)foundSpecialistes.Count}");


            Console.ReadKey();
        }
    }
}