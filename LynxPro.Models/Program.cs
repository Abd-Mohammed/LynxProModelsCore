using LynxPro.Models;
using LynxPro.Models.Infrastructure;
using LynxPro.Models.Interfaces;
using LynxPro.Models.Json;
using Microsoft.EntityFrameworkCore;

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
        b=>b.UseNetTopologySuite());
});

// Register UnitOfWork and IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILynxRepository, LynxRepository>();

// Add Sharding to the services
builder.Services.AddScoped<Sharding>();

// Add LynxDbInitializer to the services
builder.Services.AddHostedService<LynxDbInitializer>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
