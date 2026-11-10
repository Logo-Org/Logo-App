using LogoAppBackend.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connectionString)) {
    throw new InvalidOperationException("Missing default connection string");
}

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(connectionString, npgsql => npgsql.EnableRetryOnFailure());
});

if (builder.Environment.IsDevelopment()) {
    builder.Services.AddScoped<DemoDataSeeder>();
}

WebApplication app = builder.Build();

// Migrate or Seed demo data to database
if (app.Environment.IsDevelopment()) {
    bool migrate = app.Configuration.GetValue<bool>("Database:Migrate");
    bool seed = app.Configuration.GetValue<bool>("Database:ResetAndSeed");
    using IServiceScope scope = app.Services.CreateScope();
    AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (seed) {
        await db.GetService<IMigrator>().MigrateAsync("0");
    }

    if (migrate || seed) {
        await db.Database.MigrateAsync();
    }

    if (seed) {
        await scope.ServiceProvider.GetRequiredService<DemoDataSeeder>().SeedAsync();
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json", "LogoApp-API");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();