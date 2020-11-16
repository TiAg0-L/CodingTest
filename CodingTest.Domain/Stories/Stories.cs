﻿using HackerNews.Provider;
using HackerNews.Provider.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Domain.Stories
{
    /// <summary>
    /// Represents an item collection.
    /// </summary>
    public sealed class Stories : IStories
    {
        private readonly IHackerNewsAPI _api;
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Creates ab instace of <see cref="Stories"/>.
        /// </summary>
        /// <param name="api">The API to fetch data from.</param>
        public Stories(IHackerNewsAPI api, IMemoryCache cache)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        /// <summary>
        /// Gets the 20 best Stories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IStory> Get20BestStories()
        {
            return _api.GetBeststories().Select(storyId => 
                _cache.GetOrCreate(
                  storyId,
                  entry => new Story(_api.GetItem(storyId))
                )
            ).OrderByDescending(item => item.Score)
            .Take(20);
        }
    }
}
