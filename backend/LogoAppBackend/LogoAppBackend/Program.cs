WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connectionString)) {
    throw new InvalidOperationException("Missing default connection string");
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json", "Hospital");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();