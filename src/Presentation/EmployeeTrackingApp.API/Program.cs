
using EmployeeTrackingApp.API.Extensions;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using EmployeeTrackingApp.Application;
using EmployeeTrackingApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRateLimiter(options =>
{
    options.AddConcurrencyLimiter("Concurrency", configureOptions =>
    {
        configureOptions.PermitLimit = 8;
        configureOptions.QueueLimit = 2;
        configureOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRateLimiter();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();