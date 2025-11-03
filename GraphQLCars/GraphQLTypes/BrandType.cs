using GraphQLCars.Models;

namespace GraphQLCars.GraphQLTypes;

public class BrandType : ObjectType<Brand>
{
    protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
    {
        descriptor.Description("Represents a car brand");
        descriptor.Field(b => b.Id).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.Name).Type<StringType>();
        descriptor.Field(b => b.Cars)
            .ResolveWith<Resolvers>(r => r.GetCars(default!, default!))
            .Description("List of cars that belong to this brand");
    }

    private class Resolvers
    {
        public IQueryable<Car> GetCars(Brand brand, HotChocolate.AspNetCoreDbContext.AppDbContext db)
        {
            // ScopedService yerine DbContext direkt parametre
            return db.Cars.Where(c => c.BrandId == brand.Id);
        }
    }
}
