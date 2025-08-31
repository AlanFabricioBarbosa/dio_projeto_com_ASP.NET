using CarStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Api.Data;

public class CarStoreDbContext : DbContext
{
    public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
}