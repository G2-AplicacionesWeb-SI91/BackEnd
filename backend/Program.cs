using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.tracking;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Tracking Bounded Context Injection Configuration
builder.Services.AddScoped<IBusRouteRepository, BusRouteRepository>();
builder.Services.AddScoped<IBusRouteCommandService, BusRouteCommandService>();
builder.Services.AddScoped<IBusRouteQueryService, BusRouteQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
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
