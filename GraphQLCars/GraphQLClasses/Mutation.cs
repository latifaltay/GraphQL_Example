using GraphQLCars.HotChocolate.AspNetCoreDbContext;
using GraphQLCars.Models;

namespace GraphQLCars.GraphQLClasses;

public class Mutation
{
    public async Task<Brand> AddBrand(string name, AppDbContext db)
    {
        var brand = new Brand { Name = name };
        db.Brands.Add(brand);
        await db.SaveChangesAsync();
        return brand;
    }

    public async Task<Car> AddCar(string model, int brandId, AppDbContext db)
    {
        var car = new Car { Model = model, BrandId = brandId };
        db.Cars.Add(car);
        await db.SaveChangesAsync();
        return car;
    }
}
