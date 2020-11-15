using CodingTest.Domain.Stories;
using Newtonsoft.Json;
using System;

namespace CodingTest.Models.Responses
{
    /// <summary>
    /// Represents a story response.
    /// </summary>
    public class StoryResponse
    {
        private readonly DateTime? _time;

        /// <summary>
        /// Creates an instance of <see cref="StoryResponse"/>.
        /// </summary>
        /// <param name="story">The domain story model.</param>
        public StoryResponse(IStory story)
            : this(
                 title: story.Title,
                 uri: story.Uri,
                 postedBy: story.PostedBy,
                 time: story.Time,
                 score: story.Score,
                 commentCount: story.CommentCount
            )
        { }

        /// <summary>
        /// Creates an instance of <see cref="StoryResponse"/>.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="postedBy">The author.</param>
        /// <param name="time">The story release date.</param>
        /// <param name="score">The score.</param>
        /// <param name="commentCount">The comment count.</param>
        public StoryResponse(string title, string uri, string postedBy, DateTime? time, int? score, int? commentCount)
        {
            Title = title;
            Uri = uri;
            PostedBy = postedBy;
            _time = time;
            Score = score;
            CommentCount = commentCount;
        }

        /// <summary>
        /// Gets the Title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; }

        /// <summary>
        /// Gets the PostedBy.
        /// </summary>
        [JsonProperty(PropertyName = "postedBy")]
        public string PostedBy { get; }

        /// <summary>
        /// Gets the Time.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time
        {
            get
            {
                if (_time.HasValue)
                {
                    return new DateTimeOffset(_time.Value).ToString("yyyy-MM-dd'T'HH:mm:ss.ffK");

                }
                return null;
            }
        }

        /// <summary>
        /// Gets the Score.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public int? Score { get; }

        /// <summary>
        /// Gets the }.
        /// </summary>
        [JsonProperty(PropertyName = "commentCount")]
        public int? CommentCount { get; }
    }
}
