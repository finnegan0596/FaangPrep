using System;
using Problems.Common;

while (true)
{
    var problems = ProblemRegistry.GetAllProblems();
    Console.WriteLine("Available problems:");
    foreach (var p in problems)
    {
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Description}");
    }
    Console.WriteLine("Enter problem id to run (or 'q' to quit):");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) continue;
    if (input.Trim().Equals("q", StringComparison.OrdinalIgnoreCase)) break;
    var selected = Array.Find(problems, x => x.Id == input.Trim());
    if (selected == null)
    {
        Console.WriteLine("Problem not found.");
        continue;
    }
    try
    {
        var output = selected.Run();
        Console.WriteLine("--- Output ---");
        Console.WriteLine(output);
        Console.WriteLine("---------------");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error running problem: {ex}");
    }
    Console.WriteLine();
}
