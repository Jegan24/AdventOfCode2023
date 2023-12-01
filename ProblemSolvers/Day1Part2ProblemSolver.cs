namespace AdventOfCode2023.ProblemSolvers
{
    public class Day1Part2ProblemSolver : IProblemSolver
    {
        public string ProblemName { get => "01part2"; }
        private static readonly Dictionary<string, string> wordReplacements = new()
        {
            { "one",    "1oe" },
            { "two",    "2to" },
            { "three",  "3te" },
            { "four",   "4fr" },
            { "five",   "5fe" },
            { "six",    "6sx" },
            { "seven",  "7sn" },
            { "eight",  "8et" },
            { "nine",   "9ne" }
        };
        public string Solve(string input)
        {
            var lines = input.Split("\n");
            var cleanedLines = new List<string>();
            foreach (var line in lines)
            {
                var cleanedLine = Clean(line);
                cleanedLines.Add(cleanedLine);
            }

            var cleanedInput = string.Join('\n', cleanedLines);
            return new Day1Part1ProblemSolver().Solve(cleanedInput);
        }

        private static string Clean(string input)
        {
            if (!wordReplacements.Keys.Any(word => input.Contains(word)))
            {
                return input;
            }

            var wordToReplace = wordReplacements
                                .Where(word => input.Contains(word.Key))
                                .OrderBy(word => input.IndexOf(word.Key))
                                .First();

            return Clean(input.Replace(wordToReplace.Key, wordToReplace.Value));
        }
    }
}