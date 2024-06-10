using backend.Promos.Application.Internal.CommandServices;
using backend.Promos.Application.Internal.QueryServices;
using backend.Promos.Domain.Repositories;
using backend.Promos.Domain.Services;
using backend.Promos.Infrastructure.Persistence.EFC.Repositories;
using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
    {
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if(connectionString != null)
            if(builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });


//Configura LowerCase URLS
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<IPromoCommandService, PromoCommandService>();
builder.Services.AddScoped<IPromoQueryService, PromoQueryService>();


var app = builder.Build();

using (var scopre = app.Services.CreateScope())
{
    var services = scopre.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

