﻿using System.Reflection;
using AdventOfCode2023.ProblemSolvers;

namespace AdventOfCode2023
{
    public class Program
    {
        const string inputDirectory     = @"E:\Advent of Code\2023\Input";
        const string outputDirectory    = @"E:\Advent of Code\2023\Output";
        static void Main()
        {
            var problemSolvers = GetProblemSolvers();
            var inputs = GetInputs();

            foreach(var input in inputs)
            {
                var problemSolver = problemSolvers.FirstOrDefault(p => p.ProblemName == input.Key) ?? throw new Exception($"Couldn't find a problem solver for {input.Key}");
                var solution = problemSolver.Solve(input.Value);
                File.WriteAllText(@$"{outputDirectory}\{problemSolver.ProblemName}", solution);
            }
        }

        private static Dictionary<string, string> GetInputs()
        {
            var output = new Dictionary<string, string>();

            var fileNames = Directory.GetFiles(inputDirectory);

            foreach(var fullFileName in fileNames)
            {
                var fileName = fullFileName.Split('\\').Last();
                output[fileName] = File.ReadAllText(fullFileName);
            }

            return output;
        }
        
        private static IEnumerable<IProblemSolver> GetProblemSolvers()
        {            
            var problemSolvers = 
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IProblemSolver)));

            var output = new List<IProblemSolver>();

            foreach(var problemSolver in problemSolvers)
            {
                var instance = (IProblemSolver?)Activator.CreateInstance(problemSolver);
                if(instance is not null)
                {
                    output.Add(instance);
                }
            }

            return output;
        }
    }
}