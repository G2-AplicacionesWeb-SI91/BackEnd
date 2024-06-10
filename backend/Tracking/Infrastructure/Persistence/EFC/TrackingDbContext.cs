using Microsoft.EntityFrameworkCore;

namespace backend.Tracking.Infrastructure.Persistence.EFC;

public class TrackingDbContext : DbContext
{
    public DbSet<Route> Routes { get; set; }

    public TrackingDbContext(DbContextOptions<TrackingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aquí puedes configurar las convenciones de mapeo y las relaciones entre entidades si es necesario
    }
}