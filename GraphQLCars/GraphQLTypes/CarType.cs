using GraphQLCars.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLCars.GraphQLTypes;

public class CarType : ObjectType<Car>
{
    protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
    {
        descriptor.Description("Represents a car");
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.Model).Type<StringType>();
        descriptor.Field(c => c.Brand)
            .ResolveWith<Resolvers>(r => r.GetBrand(default!, default!))
            .Description("The brand of the car");
    }

    private class Resolvers
    {
        public Brand GetBrand(Car car, HotChocolate.AspNetCoreDbContext.AppDbContext db)
        {
            // ScopedService yerine DbContext direkt parametre
            return db.Brands.FirstOrDefault(b => b.Id == car.BrandId);
        }
    }
}
