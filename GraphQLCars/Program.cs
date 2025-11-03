using GraphQLCars.GraphQLQuery;
using GraphQLCars.GraphQLClasses;
using GraphQLCars.GraphQLTypes;
using GraphQLCars.HotChocolate.AspNetCoreDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// InMemory DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("CarsDb"));

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<BrandType>()
    .AddType<CarType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// GraphQL endpoint
app.MapGraphQL("/graphql");

app.Run();
