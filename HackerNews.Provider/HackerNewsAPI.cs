using HackerNews.Provider.Configurations;
using HackerNews.Provider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace HackerNews.Provider
{
    /// <summary>
    /// Represents the Hacker News API.
    /// </summary>
    public sealed class HackerNewsAPI : IHackerNewsAPI
    {
        private readonly IHackerNewsApiConfigurations _configuration;

        /// <summary>
        /// Creates an instance of <see cref="HackerNewsAPI"/>.
        /// </summary>
        /// <param name="configuration">The api configurations.</param>
        public HackerNewsAPI(IHackerNewsApiConfigurations configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Gets the best stories.
        /// </summary>
        /// <returns>A collection of ids for best stories.</returns>
        public IEnumerable<string> GetBeststories()
        {
            var endpoint = "/beststories.json";

            var response = new HttpClient().GetAsync(_configuration.BasePath + endpoint).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Unsuccessful access to best stories.");
            }

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<string[]>(jsonResult);
            }
            return new List<string>();
        }

        /// <summary>
        /// Gets the item by id.
        /// </summary>
        /// <param name="itemId">theitem id.</param>
        /// <returns>The Item, or Null if no item is found.</returns>
        public Item GetItem(string itemId)
        {
            var endpoint = $"/item/{itemId}.json";

            var response = new HttpClient().GetAsync(_configuration.BasePath + endpoint).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unsuccessful access to item with id {itemId}.");
            }

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<Item>(jsonResult);
            }
            return null;
        }
    }
}
