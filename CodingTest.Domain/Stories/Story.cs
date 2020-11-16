using HackerNews.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Domain.Stories
{
    /// <summary>
    /// Represents a story.
    /// </summary>
    public sealed class Story : IStory
    {
        private string _time;

        /// <summary>
        /// Creates an instance of <see cref="Story"/>
        /// </summary>
        /// <param name="item">The <see cref="IItem"/> to be mapped to <see cref="Story"/></param>
        public Story(IItem item)
            : this(
            title: item.Title,
            uri: item.Url,
            postedBy: item.By,
            time: item.Time,
            score: item.Score,
            kids: item.Kids
        )
        { }

        /// <summary>
        /// Creates an instance of <see cref="Story"/>
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="postedBy">The author.</param>
        /// <param name="time">Story relase date.</param>
        /// <param name="score">Score.</param>
        /// <param name="commentCount">The comment count.</param>
        public Story(string title, string uri, string postedBy, string time, int score, IEnumerable<string> kids)
        {
            Title = title;
            Uri = uri;
            PostedBy = postedBy;
            _time = time;
            Score = score;
            Kids = kids;
        }

        /// <summary>
        /// Gets the Title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the PostedBy.
        /// </summary>
        public string PostedBy { get; }

        /// <summary>
        /// Gets the Time.
        /// </summary>
        public DateTime? Time
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_time))
                {
                    return null;
                }

                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(Double.Parse(_time));
            }
        }

        /// <summary>
        /// Gets the Score.
        /// </summary>
        public int Score { get; }

        /// <summary>
        /// Gets the kids.
        /// </summary>
        public IEnumerable<string> Kids { get; }

        /// <summary>
        /// Gets the CommentCount.
        /// </summary>
        public int CommentCount
        {
            get => Kids.Count();
        }
    }
}
