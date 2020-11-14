using HackerNews.Provider.Configurations;
using Moq;
using NUnit.Framework;
using System;

namespace HackerNews.Provider.Tests
{
    [TestFixture()]
    public class HackerNewsAPITests

    {
        [Test]
        public void HackerNewsAPITest_GivenNullConfiguration_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new HackerNewsAPI(null)
            );
        }

        [Test]
        [Category("Depends on external source")]
        public void GetBeststoriesTest_GivenValidBasepath_RetunsData()
        {
            var mock = new Mock<IHackerNewsApiConfigurations>();
            mock.Setup(m => m.BasePath)
                .Returns("https://hacker-news.firebaseio.com/v0");

            var result = new HackerNewsAPI(mock.Object)
                .GetBeststories();

            Assert.IsNotEmpty(result);
        }

        [Test]
        [Category("Depends on external source")]
        public void GetBeststoriesTest_GivenInvalidBasepath_ThrowsException()
        {
            var mock = new Mock<IHackerNewsApiConfigurations>();
            mock.Setup(m => m.BasePath)
                .Returns("https://example.com/");

            var ex = Assert.Throws<Exception>(() =>
               new HackerNewsAPI(mock.Object)
                   .GetBeststories()
            );
            Assert.That(ex.Message, Is.EqualTo("Unsuccessful access to best stories."));
        }

        [Test]
        [Category("Depends on external source")]
        public void GetItemTest_GivenValidBasepathAndExistingItemId_RetunsData()
        {
            var itemId = "21233041";
            var mock = new Mock<IHackerNewsApiConfigurations>();
            mock.Setup(m => m.BasePath)
                .Returns("https://hacker-news.firebaseio.com/v0");

            var result = new HackerNewsAPI(mock.Object)
                .GetItem(itemId);

            Assert.AreEqual(itemId, result?.Id);
        }

        [Test]
        [Category("Depends on external source")]
        public void GetItemTest_GivenValidBasepathAndNonExistingItemId_Thorws()
        {
            var itemId = "shouldNotExist";
            var mock = new Mock<IHackerNewsApiConfigurations>();
            mock.Setup(m => m.BasePath)
                .Returns("https://hacker-news.firebaseio.com/v0");

            var result = new HackerNewsAPI(mock.Object)
                   .GetItem(itemId);

            Assert.IsNull(result);
        }
    }
}
