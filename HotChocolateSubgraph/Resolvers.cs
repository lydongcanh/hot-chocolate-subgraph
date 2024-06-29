namespace HotChocolateSubgraph;

public class Resolvers
{
    public async Task<Author> GetAuthorAsync([Parent] Book book, AuthorDataLoader dataLoader, CancellationToken cancellationToken)
    {
        return await dataLoader.LoadAsync(book.AuthorId, cancellationToken);
    }
}