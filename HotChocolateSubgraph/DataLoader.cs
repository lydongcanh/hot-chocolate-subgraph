namespace HotChocolateSubgraph;

public class AuthorDataLoader : BatchDataLoader<int, Author>
{
    private readonly IAuthorService _authorService;

    public AuthorDataLoader(IBatchScheduler batchScheduler, IAuthorService authorService) : base(batchScheduler)
    {
        _authorService = authorService;
    }

    protected override async Task<IReadOnlyDictionary<int, Author>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var authors = await _authorService.GetAuthorsByIdsAsync(keys, cancellationToken);
        return authors.ToDictionary(a => a.Id);
    }
}

public interface IAuthorService
{
    Task<List<Author>> GetAuthorsByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
}

public class AuthorService : IAuthorService
{
    public Task<List<Author>> GetAuthorsByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        var allAuthors = new List<Author>
        {
            new() { Id = 1, Name = "Author 1" },
            new() { Id = 2, Name = "Author 2" },
            new() { Id = 3, Name = "Author 3" },
            new() { Id = 4, Name = "Author 4" },
            new() { Id = 5, Name = "Author 5" },
        };

        var authors = allAuthors.Where(a => ids.Contains(a.Id)).ToList();
        return Task.FromResult(authors);
    }
}