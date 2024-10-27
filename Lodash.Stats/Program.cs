using Lodash.Stats;

var lodash = "lodash";

var wrapper = new GitHubWrapper();
var engine = new CharStatsEngine();

var lodashFiles = await wrapper.ListFiles(lodash, lodash);

foreach (var file in lodashFiles)
{
    if (file.EndsWith(".js") || file.EndsWith(".ts"))
    {
        var content = await wrapper.GetFileContent(lodash, lodash, file);

        engine.Add(content);

        Console.WriteLine($"Processed {file}");
    }
    else
    {
        Console.WriteLine($"Skipped {file}");
    }
}

var statistics = engine.GetAllFrequencies();

var output = statistics
    .Where(c => char.IsLetter(c.Char))
    .OrderByDescending(c => c.Frequency)
    .ToList();


Console.WriteLine($"---- stats start ----");

foreach (var item in output)
{
    Console.WriteLine($"{item.Char} : {item.Frequency}");
}

Console.WriteLine($"---- stats end ----");
Console.ReadKey(true);

// TODO: solve problem with GitHub API - rate limit exceeded
