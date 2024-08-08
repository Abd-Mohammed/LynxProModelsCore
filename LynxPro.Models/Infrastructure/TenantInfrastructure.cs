using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;

namespace LynxPro.Models.Infrastructure
{
    public static class TenantInfrastructure
    {
        private static readonly ConcurrentDictionary<int, string> _mappingDic = new ConcurrentDictionary<int, string>();

        public static void UseInMemory(IConfiguration configuration)
        {
            // Bootstrap the shard map manager, register shards, and store mappings of tenants to shards.
            var sharding = new Sharding(configuration);

            // Create connection string builder
            var shardMapManagerConnectionString = configuration.GetConnectionString("ShardMapManagerDbConnection");
            var connectionStringBuilder = new SqlConnectionStringBuilder(shardMapManagerConnectionString);

            var mappings = sharding.ShardMap.GetMappings();
            foreach (var mapping in mappings)
            {
                connectionStringBuilder.InitialCatalog = mapping.Shard.Location.Database;
                _mappingDic.TryAdd(mapping.Value, connectionStringBuilder.ConnectionString);
            }
        }

        public static IReadOnlyDictionary<int, string> ListAllMappings()
        {
            return _mappingDic;
        }

        public static string GetDatabaseName(int tenantId)
        {
            if (!_mappingDic.TryGetValue(tenantId, out var connectionString) || string.IsNullOrWhiteSpace(connectionString))
            {
                return null;
            }

            var connStrBuilder = new SqlConnectionStringBuilder(connectionString);
            return connStrBuilder.InitialCatalog;
        }

        public static string GetConnectionString(IConfiguration configuration, int key)
        {
            if (!_mappingDic.TryGetValue(key, out string connectionString))
            {
                var sharding = new Sharding(configuration);
                var mapping = sharding.ShardMap.GetMappingForKey(key);

                var shardMapManagerConnectionString = configuration.GetConnectionString("ShardMapManagerDbConnection");
                var connectionStringBuilder = new SqlConnectionStringBuilder(shardMapManagerConnectionString)
                {
                    InitialCatalog = mapping.Shard.Location.Database
                };

                connectionString = connectionStringBuilder.ConnectionString;
                _mappingDic.TryAdd(mapping.Value, connectionString);
            }

            return connectionString;
        }
    }
}