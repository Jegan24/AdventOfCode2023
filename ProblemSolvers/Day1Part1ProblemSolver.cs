namespace AdventOfCode2023.ProblemSolvers
{
    public class Day1Part1ProblemSolver : IProblemSolver
    {
        public string ProblemName { get => "01part1"; }
        public string Solve(string input)
        {
            var lines = input.Split("\n").Where(line => !string.IsNullOrEmpty(line)).ToArray();
            int sum = 0;

            foreach (var line in lines)
            {
                sum += GetValue(line);
            }

            return sum.ToString();
        }

        private static int GetValue(string line)
        {
            var numericOnlyString = new string(line.Where(char.IsDigit).ToArray());
            return int.Parse($"{numericOnlyString.First()}{numericOnlyString.Last()}");
        }
    }
}