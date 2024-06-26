using backend.IAM;
using backend.Profiles;
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

        // Profile Context
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Address).HasColumnName("EmailAddress");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Address,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Street).HasColumnName("AddressStreet");
                n.Property(p => p.Number).HasColumnName("AddressNumber");
                n.Property(p => p.city).HasColumnName("AddressCity");
                n.Property(p => p.PostalCode).HasColumnName("AddressPostalCode");
                n.Property(p => p.country).HasColumnName("AddressCountry");
            });

        //IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();


        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}