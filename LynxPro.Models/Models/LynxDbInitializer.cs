using LynxPro.Models.Seeds;
using Microsoft.EntityFrameworkCore;

namespace LynxPro.Models
{
    public class LynxDbInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public LynxDbInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //var context = scope.ServiceProvider.GetRequiredService<LynxContext>();
                ////await context.Database.MigrateAsync(cancellationToken);

                //PermissionSeeder.TrySeed(context);
                //EventTypeSeeder.Seed(context);
                //AlarmTypeSeeder.Seed(context);
                //HosStatusSeeder.Seed(context);
                //VehicleInspectionSeeder.Seed(context);
                //TrailerInspectionSeeder.Seed(context);

                //await context.SaveChangesAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }

    public static class LynxDbInitializerExtensions
    {
        public static IHostBuilder UseLynxDbInitializer(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddHostedService<LynxDbInitializer>();
            });

            return hostBuilder;
        }
    }
}