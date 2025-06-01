SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var input = File.ReadAllText("input1.txt");
    var tree  = ConstructTree(input);
    Console.WriteLine("Constructed Tree:");
    foreach (var line in tree)
    {
        Console.WriteLine(line);
    }

    var result = tree.OrderBy(x => x.Length).First();
    Console.WriteLine($"Part 1 result: {result}");
}

void SolvePart2()
{
    var input  = File.ReadAllText("input2.txt");
    var result = 0;
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}

List<string> ConstructTree(string input)
{
    const string treeRoot = "RR";
    var          tree     = new List<string>();
    var          lines    = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    var          root     = lines.First(line => line.StartsWith("RR"));
    lines.Sort();
    lines.Remove(root);
    lines.Insert(0, root);

    foreach (var line in lines)
    {
        var node = new Node(line);
        foreach (var branch in node.Branches)
        {
            if (node.Root.Equals(treeRoot))
            {
                tree.Add($"{node.Root}{branch}");
                continue;
            }

            // Find the parent path in the tree
            var parentPath = tree.FirstOrDefault(p => p.EndsWith(node.Root));

            // If a parent path is found, append the branch to it
            var index = string.IsNullOrWhiteSpace(parentPath) ? -1 : tree.IndexOf(parentPath);
            if (index != -1)
            {
                tree[index] = $"{parentPath}{branch}";
            }
            else
            {
                // If no parent path found, add the branch directly
                tree.Add($"{treeRoot}{node.Root}{branch}");
            }
        }
    }

    // Sanity check; ensure the tree starts with the root node and ends with '@'

    if (tree.Any() && tree.All(branch => branch.StartsWith(treeRoot)) && tree.All(branch => branch.EndsWith('@')))
    {
        return tree;
    }

    Console.WriteLine("*** ERROR *** Not all branches have fruit!");
    foreach (var branch in tree)
    {
        Console.WriteLine(branch);
    }

    Console.ReadKey();
    return tree;
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