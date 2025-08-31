using CarStore.Api.Data;
using CarStore.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CarStore API", Version = "v1" });
});

builder.Services.AddDbContext<CarStoreDbContext>(options =>
    options.UseInMemoryDatabase("CarInventoryDB"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarStoreDbContext>();
    if (!dbContext.Cars.Any())
    {
        dbContext.Cars.AddRange(
            new Car { Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000.00m, Color = "Red" },
            new Car { Make = "Toyota", Model = "Corolla", Year = 2023, Price = 25000.00m, Color = "Silver" },
            new Car { Make = "Honda", Model = "Civic", Year = 2021, Price = 22000.00m, Color = "Black", IsAvailable = false },
            new Car { Make = "Tesla", Model = "Model 3", Year = 2024, Price = 52000.00m, Color = "White" }
        );
        dbContext.SaveChanges();
    }
}

var carApi = app.MapGroup("/cars");

carApi.MapGet("/", async (CarStoreDbContext db) =>
{
    var cars = await db.Cars.ToListAsync();
    return Results.Ok(cars);
});

carApi.MapGet("/{id:int}", async (int id, CarStoreDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car is null)
    {
        return Results.NotFound($"Car with ID {id} not found.");
    }

    return Results.Ok(car);
});

carApi.MapPost("/", async (Car car, CarStoreDbContext db) =>
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();

    return Results.Created($"/cars/{car.Id}", car);
});

carApi.MapPut("/{id:int}", async (int id, Car updatedCar, CarStoreDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car is null)
    {
        return Results.NotFound($"Car with ID {id} not found.");
    }

    car.Make = updatedCar.Make;
    car.Model = updatedCar.Model;
    car.Year = updatedCar.Year;
    car.Price = updatedCar.Price;
    car.Color = updatedCar.Color;
    car.IsAvailable = updatedCar.IsAvailable;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

carApi.MapDelete("/{id:int}", async (int id, CarStoreDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car is null)
    {
        return Results.NotFound($"Car with ID {id} not found.");
    }

    db.Cars.Remove(car);
    await db.SaveChangesAsync();

    return Results.Ok(car);
});

app.MapGet("/", () => "Welcome to the CarStore API!");

app.Run();