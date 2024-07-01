namespace HotChocolateSubgraph;

public class Me
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}


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

public class MeType : ObjectType<Me>
{
    protected override void Configure(IObjectTypeDescriptor<Me> descriptor)
    {
        descriptor.BindFieldsImplicitly();
    }
}

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(t => t.Id).Type<IdType>();
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
        descriptor.BindFieldsImplicitly();
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}