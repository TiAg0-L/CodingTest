using CodingTest.Domain.Stories;
using HackerNews.Provider;
using HackerNews.Provider.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainStories = CodingTest.Domain.Stories;


namespace CodingTest.DomainTests.Stories
{
    [TestFixture]
    public class StoriesTests
    {
        private IServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void StoriesTest_GivenNullAPI_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new DomainStories.Stories(
                api: null,
                cache: null
            ));
        }

        [Test]
        public void StoriesTest_GivenNullCache_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new DomainStories.Stories(
                api: new Mock<IHackerNewsAPI>().Object,
                cache: null
            ));
        }

        [Test]
        public void Get20BestStoriesTest_Given1Story_ReturnsExpectedStory()
        {
            var item = new Item
            {
                Title = "A title",
                Url = "https://www.example.com",
                By = "An author",
                Time = "1",
                Descendants = "2",
                Score = 3,
                Id = "4",
                Kids = new string[] { "5", "6" },
                Type = "story"
            };
            var expectedStory = new Story(
                title: item.Title,
                uri: item.Url,
                postedBy: item.By,
                time: item.Time,
                score: item.Score,
                kids: item.Kids
            );
            var apiMock = new Mock<IHackerNewsAPI>();
            apiMock.Setup((m) => m.GetBeststories()).Returns(new string[] { item.Id });
            apiMock.Setup((m) => m.GetItem(item.Id)).Returns(item);

            var result = new DomainStories.Stories(
                api: apiMock.Object,
                cache: _serviceProvider.GetService<IMemoryCache>()
            ).Get20BestStories();
            var firstResult = result.First();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(expectedStory.CommentCount, firstResult.CommentCount);
            Assert.AreEqual(expectedStory.PostedBy, firstResult.PostedBy);
            Assert.AreEqual(expectedStory.Score, firstResult.Score);
            Assert.AreEqual(expectedStory.Time, firstResult.Time);
            Assert.AreEqual(expectedStory.Title, firstResult.Title);
            Assert.AreEqual(expectedStory.Uri, firstResult.Uri);
        }

        [Test]
        public void Get20BestStoriesTest_Given21Stories_Returns20StoriesWithBestScore()
        {
            var apiMock = new Mock<IHackerNewsAPI>();
            var items = new List<Item>();
            for (int i = 0; i < 21; i++)
            {
                var item =
                   new Item
                   {
                       Title = "A title",
                       Url = "https://www.example.com",
                       By = "An author",
                       Time = "1",
                       Descendants = "2",
                       Score = i,
                       Id = i.ToString(),
                       Kids = new string[] { "5", "6" },
                       Type = "story"
                   };
                items.Add(item);

                apiMock.Setup((m) => m.GetItem(item.Id)).Returns(item);

            }
            apiMock.Setup((m) => m.GetBeststories()).Returns(items.Select(item => item.Id));

            var result = new DomainStories.Stories(
                api: apiMock.Object,
                cache: _serviceProvider.GetService<IMemoryCache>()
            ).Get20BestStories();

            Assert.AreEqual(20, result.Count());
            Assert.That(result, Has.No.Member(items.Where(item => item.Score == 0)));
        }
    }
}
