namespace HackerNews.Provider.Configurations
{
    /// <summary>
    /// Contains all configurations required for the Hacker News Api provider.
    /// </summary>
    public interface IHackerNewsApiConfigurations
    {
        /// <summary>
        /// Gets the base path.
        /// </summary>
        string BasePath { get; }
    }
}