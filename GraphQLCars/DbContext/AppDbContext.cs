using GraphQLCars.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLCars.HotChocolate.AspNetCoreDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {

    }

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Car> Cars => Set<Car>();
}