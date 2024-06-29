using HotChocolateSubgraph;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", b =>
            b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    })
    .AddGraphQLServer()
    .AddDataLoader<AuthorDataLoader>()
    .AddQueryType<Query>()
    .AddType<BookType>()
    .AddType<AuthorType>()
    .AddFiltering()
    .AddSorting()
    .AddApolloFederationV2();

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.MapGet("/", () => "Hello World!");
app.MapGraphQL();
app.MapGraphQLSchema();
app.Run();