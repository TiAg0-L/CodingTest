using System;

namespace HackerNews.Provider.Configurations
{
    /// <summary>
    /// Contains all configurations required for the Hacker News Api provider.
    /// </summary>
    public sealed class HackerNewsApiConfigurations : IHackerNewsApiConfigurations
    {
        /// <summary>
        /// Creas an instance of <see cref="HackerNewsApiConfigurations"/>.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public HackerNewsApiConfigurations(string basePath)
        {
            BasePath = basePath ?? throw new ArgumentNullException(nameof(basePath));
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath { get; }
    }
}
