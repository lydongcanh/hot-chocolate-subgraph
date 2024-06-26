using HotChocolateSubgraph;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", b =>
            b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    })
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<DataRoomType>()
    .AddType<FolderType>()
    .AddType<DocumentType>()
    .AddApolloFederationV2();

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.MapGet("/", () => "Hello World!");
app.MapGraphQL();
app.MapGraphQLSchema();
app.Run();