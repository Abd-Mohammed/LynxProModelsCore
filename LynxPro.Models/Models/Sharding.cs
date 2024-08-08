using Microsoft.Azure.SqlDatabase.ElasticScale.ShardManagement;
using System.Data.SqlClient;

namespace LynxPro.Models
{
    public class Sharding
    {
        private readonly IConfiguration _configuration;

        public ShardMapManager ShardMapManager { get; private set; }

        public ListShardMap<int> ShardMap { get; private set; }

        public Sharding(IConfiguration configuration)
        {
            _configuration = configuration;
            var shardMapManagerConnectionString = _configuration.GetConnectionString("ShardMapManagerDbConnection");

            // Deploy shard map manager.
            if (!ShardMapManagerFactory.TryGetSqlShardMapManager(shardMapManagerConnectionString, ShardMapManagerLoadPolicy.Lazy, out ShardMapManager smm))
            {
                ShardMapManager = ShardMapManagerFactory.CreateSqlShardMapManager(shardMapManagerConnectionString);
            }
            else
            {
                ShardMapManager = smm;
            }

            if (!ShardMapManager.TryGetListShardMap("ElasticScale", out ListShardMap<int> sm))
            {
                ShardMap = ShardMapManager.CreateListShardMap<int>("ElasticScale");
            }
            else
            {
                ShardMap = sm;
            }
        }

        public string GetShardConnectionString(int tenantId)
        {
            var shardMapConnectionString = _configuration.GetConnectionString("ShardMapManagerDbConnection");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(shardMapConnectionString);
            string shardUsername = builder.UserID;
            string shardPassword = builder.Password;

            var shard = ShardMap.GetMappings().FirstOrDefault(x => x.Value == tenantId);
            if (shard == null)
            {
                throw new KeyNotFoundException($"No shard found for tenant ID {tenantId}");
            }

            var shardServer = shard.Shard.Location.Server;
            var shardDatabase = shard.Shard.Location.Database;

            return $"Server={shardServer}; Initial Catalog={shardDatabase}; Persist Security Info=False; User ID={shardUsername}; Password={shardPassword}; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";
        }
    }
}