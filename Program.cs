using System;
using System.Collections.Generic;


int kitsCount = int.Parse(Console.ReadLine() ?? "_");

for (int _ = 0; _ < kitsCount; _++)
{
    Console.ReadLine();
    int moduleCount = int.Parse(Console.ReadLine() ?? "_");

    var targets = new Dictionary<string, List<string>>();
    for (int i = 0; i < moduleCount; i++)
    {
        string[] items = (Console.ReadLine() ?? "_").Split(' ', ':').Where(s => s != "").ToArray();
        targets.Add(items[0], items.Take(1..).ToList());
    }


    int queriesCount = int.Parse(Console.ReadLine() ?? "_");
    var compiled = new List<string>(targets.Count);
    for (int __ = 0; __ < queriesCount; __++)
    {
        string query = Console.ReadLine() ?? "_";
        var compiledHere = ResolveTarget(query);

        Console.Write($"{compiledHere.Count}");
        foreach (string target in compiledHere)
            Console.Write($" {target}");
        Console.WriteLine();
    }
    Console.WriteLine();


    List<string> ResolveTarget(string query)
    {
        if (compiled.Contains(query))
        {
            return new List<string>(0);
        }

        var compiledHere = new List<string>();
        foreach (string dependency in targets[query])
        {
            compiledHere.AddRange(ResolveTarget(dependency));
        }
        compiled.Add(query);
        compiledHere.Add(query);
        return compiledHere;
    }
}
