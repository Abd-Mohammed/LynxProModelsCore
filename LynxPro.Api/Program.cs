using FluentValidation;
using FluentValidation.AspNetCore;
using LynxPro.Models.Infrastructure;
using LynxPro.Models.Json;
using LynxPro.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using LynxPro.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new LynxContextOptions
{
    FranchiseId = 0,
    ShardingKey = 602,
    FranchiseIds = [1, 2, 3],
    SmmDbConnectionString = builder.Configuration.GetConnectionString("ShardMapManagerDbConnection")
});

// Configure services
builder.Services.AddDbContext<LynxContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var shardingKey = 602;
    options.UseSqlServer(TenantInfrastructure.GetConnectionString(configuration, shardingKey),
        b => b.UseNetTopologySuite());
});

// Register UnitOfWork and IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILynxRepository, LynxRepository>();

// Add Sharding to the services
builder.Services.AddScoped<Sharding>();

// Add LynxDbInitializer to the services
builder.Services.AddHostedService<LynxDbInitializer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
