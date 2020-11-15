using CodingTest.Controllers;
using CodingTest.Domain.Stories;
using CodingTest.Models.Responses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestTests.Controllers
{
    [TestFixture]
    public class StoriesControllerTests
    {
        [Test]
        public void StoriesControllerTest_NullStories_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new StoriesController(stories: null)
            );
        }

        [Test]
        public void GetTest_Existing1Story_ReturnsEquivalentResponseModel()
        {
            var story = new Story(
                title: "A title",
                uri: "https://www.example.com",
                postedBy: "An author",
                time: "1",
                score: 2,
                commentCount: 3
            );
            var storiesMock = new Mock<IStories>();
            storiesMock.Setup(m => m.Get20BestStories())
                .Returns(new List<IStory> { story });
            var expectedStory = new StoryResponse(story);


            var result = new StoriesController(stories: storiesMock.Object)
                .Get();
            var firstResult = result.First();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(expectedStory.CommentCount, firstResult.CommentCount);
            Assert.AreEqual(expectedStory.PostedBy, firstResult.PostedBy);
            Assert.AreEqual(expectedStory.Score, firstResult.Score);
            Assert.AreEqual(expectedStory.Time, firstResult.Time);
            Assert.AreEqual(expectedStory.Title, firstResult.Title);
            Assert.AreEqual(expectedStory.Uri, firstResult.Uri);
        }
    }
}
