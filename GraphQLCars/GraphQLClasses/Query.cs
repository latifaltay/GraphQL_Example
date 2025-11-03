using GraphQLCars.HotChocolate.AspNetCoreDbContext;
using GraphQLCars.Models;

namespace GraphQLCars.GraphQLQuery;

public class Query
{
    public IQueryable<Brand> GetBrands([Service] AppDbContext db)
    {
        return db.Brands;
    }

    public IQueryable<Car> GetCars([Service] AppDbContext db)
    {
        return db.Cars;
    }

}
