using backend.Promos.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Promo>().HasKey(t => t.Id);
        builder.Entity<Promo>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Promo>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Promo>().Property(t => t.Description).HasMaxLength(240);
        
        
        base.OnModelCreating(builder);
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}