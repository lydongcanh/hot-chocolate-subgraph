using HotChocolateSubgraph.DTOs;

namespace HotChocolateSubgraph.GraphQL;

public class ProfileType : ObjectType<Profile>
{
    protected override void Configure(IObjectTypeDescriptor<Profile> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(p => p.Id).ID();
        
        descriptor.Field(p => p.Projects)
            .Type<ListType<ProjectType>>()
            .ResolveWith<Resolvers>(r => r.GetProjectsByUser());
    }
}

public class ProjectType : ObjectType<Project>
{
    protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(p => p.Id).ID();
        descriptor.Field(p => p.Name).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Description).Type<StringType>();
        
        descriptor.Field(p => p.Modules)
            .Type<ListType<ModuleType>>()
            .ResolveWith<Resolvers>(r => r.GetModulesByProject());
    }
}

public class ModuleType : ObjectType<Module>
{
    protected override void Configure(IObjectTypeDescriptor<Module> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(p => p.Id).ID();
        descriptor.Field(m => m.Name).Type<NonNullType<StringType>>();
        descriptor.Field(m => m.Description).Type<StringType>();
    }
}