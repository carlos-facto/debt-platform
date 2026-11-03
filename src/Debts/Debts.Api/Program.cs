var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DebtsDb")
    ?? throw new InvalidOperationException("Connection string 'DebtsDb' not found.");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHealthChecks()
    .AddSqlServer(connectionString, name: "sqlserver");
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
