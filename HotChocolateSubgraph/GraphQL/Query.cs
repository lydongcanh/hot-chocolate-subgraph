using ApolloGraphQL.HotChocolate.Federation;
using HotChocolateSubgraph.DTOs;

namespace HotChocolateSubgraph.GraphQL;

public class Query
{
    [Shareable]
    public Profile Me([Service] Resolvers resolver) => resolver.ResolveProfile();
}