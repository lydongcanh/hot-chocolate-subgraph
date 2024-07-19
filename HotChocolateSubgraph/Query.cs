using System.Security.Claims;
using HotChocolate.Resolvers;

namespace HotChocolateSubgraph;

public class Query
{
    [UsePaging(MaxPageSize = 1000, IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public List<Book> GetBooks()
    {
        return GenerateMockBooks(1000);
    }

    public Me Me(IResolverContext context)
    {
        var user = context.GetUser();
        return new Me
        {
            UserId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "",
            Name = user?.FindFirst(ClaimTypes.Name)?.Value ?? "",
            Email = user?.FindFirst(ClaimTypes.Email)?.Value ?? "",
            Roles = user?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList() ?? Array.Empty<string>().ToList(),
        };
    }
    
    private List<Book> GenerateMockBooks(int count)
    {
        var books = new List<Book>();
        var random = new Random();

        for (var i = 0; i < count; i++)
        {
            books.Add(new Book
            {
                Id = i,
                Title = $"Book {i}",
                AuthorId = random.Next(1, 6)
            });
        }

        return books;
    }
}