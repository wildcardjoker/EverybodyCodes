SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var input = File.ReadAllText("input1.txt");
    var tree  = ConstructTree(input);

    //DisplayTreeStats(tree);

    // Find the unique path (only one branch will have a unique length)
    var result = GetMostPowerfulFruit(tree);
    Console.WriteLine($"Part 1 result: {result}");

}

void SolvePart2()
{
    var input = File.ReadAllText("input2.txt");
    var tree  = ConstructTree(input);

    //DisplayTreeStats(tree);

    var result = GetMostPowerfulFruit(tree);

    //Console.WriteLine($"The most powerful fruit is on path {result}");

    // Remove the first 2 characters, then extract the first character from each group of 4 characters
    result = GetDescriptivePath(result);
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var input = File.ReadAllText("input3.txt");
    var tree  = ConstructTree(input);

    //DisplayTreeStats(tree);
    var result = GetMostPowerfulFruit(tree);

    //Console.WriteLine($"The most powerful fruit is on path {result}");

    result = GetDescriptivePath(result);
    Console.WriteLine($"Part 3 result: {result}");
}

List<string> ConstructTree(string input)
{
    // Split the input into lines, remove empty entries, and sort them
    var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    var root  = lines.First(line => line.StartsWith("RR:"));
    lines.Sort();

    // Remove the root from the list of lines to process
    lines.Remove(root);

    var nodes = new Queue<Node>(lines.Select(line => new Node(line)));

    // Initialize the tree with the root node and its branches
    var rootNode = new Node(root);
    var tree     = rootNode.Branches.Select(branch => $"{rootNode.Root}{branch}").ToList();

    while (nodes.Any())
    {
        // Dequeue the next node to process; removes it from the queue
        var node = nodes.Dequeue();

        // Find all paths that end with the current node's root
        var paths = tree.Where(p => p.EndsWith(node.Root)).ToList();
        if (!paths.Any())
        {
            if (nodes.Any(treeNode => treeNode.Branches.Contains(node.Root)))
            {
                nodes.Enqueue(node); // Re-queue the node if no paths found
            }

            continue;
        }

        foreach (var path in paths)
        {
            // Add branches to the existing paths
            tree.AddRange(node.Branches.Select(branch => $"{path}{branch}"));

            // Remove the original path since we are extending it
            tree.Remove(path);
        }
    }

    // Remove branches that don't have fruit (i.e., don't end with '@')
    return tree.Where(branch => branch.EndsWith('@')).ToList();
}

void DisplayTreeStats(List<string> list)
{
    foreach (var line in list)
    {
        Console.WriteLine(line);
    }

    Console.WriteLine($"Total branches: {list.Count}");
    foreach (var treeBranches in list.GroupBy(t => t.Length))
    {
        Console.WriteLine($"Length of {treeBranches.Key}: {treeBranches.Count()}");
    }
}

string GetMostPowerfulFruit(List<string> list)
{
    return list.GroupBy(t => t.Length).OrderBy(g => g.Count()).First().First();
}

string GetDescriptivePath(string s)
{
    var pathWithoutRoot = new string(s[2..].Where((c, i) => i % 4 == 0).ToArray());
    return $"R{pathWithoutRoot}";
}

internal class Node
{
    #region Constructors
    public Node(string input)
    {
        var parts = input.Split(':');
        Branches = parts.Length > 1 ? parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries) : [];
        Root     = parts[0].Trim();
    }

    public Node(string root, string[] branches)
    {
        Root     = root;
        Branches = branches;
    }
    #endregion

    #region Properties
    public string[] Branches {get;}
    public string   Root     {get;}
    #endregion

    public override string ToString() => $"{Root}: {string.Join(", ", Branches)}";
}