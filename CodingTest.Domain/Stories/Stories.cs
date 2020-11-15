using HackerNews.Provider;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProviderModels = HackerNews.Provider.Models;

namespace CodingTest.Domain.Stories
{
    /// <summary>
    /// Represents an item collection.
    /// </summary>
    public sealed class Stories : IStories
    {
        private readonly IHackerNewsAPI _api;

        /// <summary>
        /// Creates ab instace of <see cref="Stories"/>.
        /// </summary>
        /// <param name="api">The API to fetch data from.</param>
        public Stories(IHackerNewsAPI api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        /// <summary>
        /// Gets the 20 best Stories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IStory> Get20BestStories()
        {
            var storyIds = _api.GetBeststories();
            var storiesDict = new ConcurrentDictionary<string, ProviderModels.IItem>();

            Parallel.ForEach(storyIds, (storyId) =>
                {
                    var story = _api.GetItem(storyId);
                    storiesDict.AddOrUpdate(storyId, story, (key, updatedValue) => story);
                }
            );

            var top20StoriesDict = storiesDict
                .OrderByDescending(story => story.Value.Score)
                .Take(20);

            var results = new ConcurrentBag<IStory>();
            Parallel.ForEach(top20StoriesDict, (storyentry) =>
                {
                    results.Add(
                        new Story(
                            title: storyentry.Value.Title,
                            uri: storyentry.Value.Url,
                            postedBy: storyentry.Value.By,
                            time: storyentry.Value.Time,
                            score: storyentry.Value.Score,
                            commentCount: storyentry.Value.Kids.Count()
                        )
                    );
                }
            );

            return results.ToList();
        }
    }
}
