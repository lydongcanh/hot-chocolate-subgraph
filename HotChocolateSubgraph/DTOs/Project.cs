namespace HotChocolateSubgraph.DTOs;

public class Project
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Module> Modules { get; set; }
}