namespace HotChocolateSubgraph;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(t => t.Id).Type<NonNullType<IntType>>();
        descriptor.Field(t => t.Title).Type<StringType>();
        descriptor.Field(t => t.Author).Type<StringType>();
    }
}