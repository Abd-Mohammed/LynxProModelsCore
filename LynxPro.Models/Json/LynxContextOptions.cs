namespace LynxPro.Models.Json;

public class LynxContextOptions
{
    public string SmmDbConnectionString { get; init; }

    public int ShardingKey { get; init; }

    public List<int> FranchiseIds { get; init; }

    public int? FranchiseId { get; init; }
}