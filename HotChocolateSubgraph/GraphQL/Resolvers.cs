using HotChocolateSubgraph.DTOs;

namespace HotChocolateSubgraph.GraphQL;

public class Resolvers
{
    private static readonly List<Module> MockModules = new()
    {
        new Module { Id = Guid.NewGuid().ToString(), Name = "User Authentication", Description = "Handles user login, registration, and password recovery" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Payment Processing", Description = "Integrates with payment gateways to handle transactions" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Inventory Management", Description = "Tracks product stock levels and manages reordering" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Analytics Dashboard", Description = "Provides visual representations of key business metrics" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Email Notification", Description = "Sends automated emails for various system events" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Search Functionality", Description = "Implements full-text search across products and content" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Content Management", Description = "Allows creation and editing of website content" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Order Tracking", Description = "Monitors order status from placement to delivery" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "Customer Support Ticketing", Description = "Manages customer inquiries and support requests" },
        new Module { Id = Guid.NewGuid().ToString(), Name = "API Integration", Description = "Connects with third-party services via RESTful APIs" }
    };

    private static readonly List<Project> MockProjects = new()
    {
        new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = "E-commerce Platform Overhaul",
            Description = "Modernizing our online store with improved UX and backend efficiency",
            Modules = new List<Module> { MockModules[0], MockModules[1], MockModules[2], MockModules[5] }
        },
        new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Customer Relationship Management System",
            Description = "Developing a comprehensive CRM to streamline customer interactions",
            Modules = new List<Module> { MockModules[3], MockModules[4], MockModules[8] }
        },
        new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Content Delivery Network Implementation",
            Description = "Setting up a global CDN to improve website performance and reliability",
            Modules = new List<Module> { MockModules[6], MockModules[9] }
        },
        new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Mobile App Development",
            Description = "Creating iOS and Android apps for our services",
            Modules = new List<Module> { MockModules[0], MockModules[5], MockModules[7] }
        },
        new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Data Analytics Platform",
            Description = "Building a robust system for analyzing and visualizing business data",
            Modules = new List<Module> { MockModules[3], MockModules[9] }
        }
    };

    public List<Module> GetModulesByProject()
    {
        return MockModules;
    }
    
    public List<Project> GetProjectsByUser()
    {
        return MockProjects;
    }
    
    public Profile ResolveProfile()
    {
        return new Profile
        {
            Id = "123e4567-e89b-12d3-a456-426614174000",
            Projects = MockProjects
        };
    }
}