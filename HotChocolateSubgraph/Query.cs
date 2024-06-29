namespace HotChocolateSubgraph;

public class Query
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public List<Book> GetBooks()
    {
        return GenerateMockBooks(100);
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
                Author = $"Author {random.Next(1, 6)}" // Random author selection
            });
        }

        return books;
    }
}