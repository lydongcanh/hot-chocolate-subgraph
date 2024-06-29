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