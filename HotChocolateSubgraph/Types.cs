namespace HotChocolateSubgraph;

public class DataRoom
{
    public string Name { get; set; }
    public Folder[] Folders { get; set; }
}

public class Folder
{
    public string Name { get; set; }
    public Document[] Documents { get; set; }
}

public class Document
{
    public string Name { get; set; }
}