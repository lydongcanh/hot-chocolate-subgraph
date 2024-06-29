namespace HotChocolateSubgraph;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(t => t.Id).Type<NonNullType<IntType>>();
        descriptor.Field(t => t.Title).Type<StringType>();
        descriptor.Field(t => t.AuthorId).Ignore();

        descriptor
            .Field("author")
            .ResolveWith<Resolvers>(r => r.GetAuthorAsync(default!, default!, default))
            .Type<AuthorType>();
    }
}

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(t => t.Id).Type<NonNullType<IntType>>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}