namespace consolidation_csharp_lesson_7;

public class FileTreeNode
{
    public string Name { get; set; }

    public FileTreeNode(string name)
    {
        Name = name;
    }
}

public class DirectoryNode : FileTreeNode
{
    public List<FileTreeNode> Contents { get; }

    public DirectoryNode(string name) : base(name)
    {
        Contents = new List<FileTreeNode>();
    }

    public void AddChild(FileTreeNode childItem)
    {
        Contents.Add(childItem);
    }
}

public class FileTree
{
    public FileTreeNode Root { get; }

    public FileTree(FileTreeNode root)
    {
        Root = root;
    }

    public void PrintUsingDFS()
    {
        // Implement the print using DFS.
    }
}
