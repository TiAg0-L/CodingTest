namespace HackerNews.Provider.Configurations
{
    /// <summary>
    /// Contains all configurations required for the Hacker News Api provider.
    /// </summary>
    public sealed class HackerNewsApiConfigurations : IHackerNewsApiConfigurations
    {
        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath { get; set; }
    }
}
