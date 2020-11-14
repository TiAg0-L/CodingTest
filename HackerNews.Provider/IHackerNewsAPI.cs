using HackerNews.Provider.Models;
using System.Collections.Generic;

namespace HackerNews.Provider
{
    /// <summary>
    /// Represents the Hacker News API.
    /// </summary>
    public interface IHackerNewsAPI
    {
        /// <summary>
        /// Gets the best stories.
        /// </summary>
        /// <returns>A collection of ids for best stories.</returns>
        IEnumerable<string> GetBeststories();
        
        /// <summary>
        /// Gets the item by id.
        /// </summary>
        /// <param name="itemId">theitem id.</param>
        /// <returns>The Item, or Null if no item is found.</returns>
        Item GetItem(string itemId);
    }
}