using CodingTest.Domain.Stories;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodingTest.DomainTests.Stories
{
    [TestFixture]
    public class StoryTests
    {
        [Test]
        public void TimeTest_GivenNullTime_ReturnsNull()
        {
            var result = new Story(
                title: null,
                uri: null,
                postedBy: null,
                time: null,
                score: 0,
                kids: new List<string>()
            ).Time;

            Assert.IsNull(result);
        }

        [Test]
        public void TimeTest_GivenEmptyTimeString_ReturnsNull()
        {
            var result = new Story(
                title: null,
                uri: null,
                postedBy: null,
                time: null,
                score: 0,
                kids: new List<string>()
            ).Time;

            Assert.IsNull(result);
        }

        [Test]
        public void TimeTest_GivenWhiteTimeString_ReturnsNull()
        {
            var result = new Story(
                title: null,
                uri: null,
                postedBy: null,
                time: null,
                score: 0,
                kids: new List<string>()
            ).Time;

            Assert.IsNull(result);
        }

        [Test]
        public void TimeTest_GivenSecondsFromUnixEpochToNow_ReturnsCorrectValue()
        {
            var expectedDateTime = new DateTime(2020, 1, 1, 1, 1, 1, DateTimeKind.Utc);
            var totalSeconds = (expectedDateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                .TotalSeconds;

            var result = new Story(
                title: null,
                uri: null,
                postedBy: null,
                time: totalSeconds.ToString(),
                score: 0,
                kids: new List<string>()
            ).Time;

            Assert.AreEqual(expectedDateTime, result);
        }
    }
}
