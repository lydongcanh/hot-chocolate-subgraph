namespace HotChocolateSubgraph.DTOs;

public class Profile
{
    public string Id { get; set; }
    public IEnumerable<Project> Projects { get; set; }
}