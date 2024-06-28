using backend.Notifications.Domain.Model.Aggregates;
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
        base.OnModelCreating(builder);
        
        // Notification Context
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Entity<Notification>().Property(n => n.NotificationDetails.Title).IsRequired();
        builder.Entity<Notification>().Property(n => n.NotificationDetails.Description).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}