namespace WhereAreYou.Core.Intefaces
{
    public interface IDatabaseSettings
    {
        string CosmosEndpoint { get; set; }
        string EmulatorKey { get; set; }
        string DatabaseId { get; set; }
        string CollectionId { get; set; }
    }
}