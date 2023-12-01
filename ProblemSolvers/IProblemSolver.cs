namespace AdventOfCode2023.ProblemSolvers
{
    internal interface IProblemSolver
    {
        string ProblemName { get; }
        string Solve(string input);
    }
}