namespace HotChocolateSubgraph;

public class DataRoom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Folder[] Folders { get; set; }
}

public class Folder
{
    public string Name { get; set; }
    public Document[] Documents { get; set; }
}

public class Document
{
    public string Name { get; set; }
}

public class DataRoomType : ObjectType<DataRoom>
{
    protected override void Configure(IObjectTypeDescriptor<DataRoom> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(dr => dr.Id).Type<NonNullType<IntType>>();
        descriptor.Field(dr => dr.Name).Type<NonNullType<StringType>>();
        descriptor.Field(dr => dr.Folders).Type<ListType<FolderType>>();
    }
}

public class FolderType : ObjectType<Folder>
{
    protected override void Configure(IObjectTypeDescriptor<Folder> descriptor)
    {
        descriptor.Field(f => f.Name).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Documents).Type<ListType<DocumentType>>();
    }
}

public class DocumentType : ObjectType<Document>
{
    protected override void Configure(IObjectTypeDescriptor<Document> descriptor)
    {
        descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
    }
}
