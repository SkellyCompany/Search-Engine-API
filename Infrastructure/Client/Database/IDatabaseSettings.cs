namespace SearchEngine.API.Infrastructure.Client.Database
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}