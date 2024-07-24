using System.Security.Cryptography;
using System.Text;
using HotChocolate.Execution;
using HotChocolateSubgraph.DTOs;
using HotChocolateSubgraph.GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Auth
const string key = "my-very-long-and-strong-secret-key!";
var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
var signingKey = new SymmetricSecurityKey(hmac.Key);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                IssuerSigningKey = signingKey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateSignatureLast = false,
                ValidateTokenReplay = false,
                ValidateWithLKG = false
            };
        
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogError("Authentication failed: {ExceptionMessage}", context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Token validated: {@SecurityToken}", context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

// Services
builder.Services.AddAuthorization();
builder.Services.AddSingleton<Resolvers>();

// Graph
builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", b =>
            b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    })
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddType<ProfileType>()
    .AddType<ProjectType>()
    .AddType<ModuleType>()
    .AddFiltering()
    .AddSorting()
    .AddApolloFederationV2()
    .AllowIntrospection(true);

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Hello World!");
app.MapGraphQL();
app.MapGraphQLSchema();

if (args.Any(c => c == "--generate-schema"))
{
    var executor = app.Services.GetRequiredService<IRequestExecutorResolver>().GetRequestExecutorAsync().Result;
    var schema = executor.Schema.Print();
    await File.WriteAllTextAsync("./GraphQL/schema.graphql", schema);
}
else
{
    app.Run();
}
