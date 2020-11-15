using System;

namespace CodingTest.Domain.Stories
{
    /// <summary>
    /// Represents a story.
    /// </summary>
    public interface IStory
    {
        /// <summary>
        /// Gets the CommentCount.
        /// </summary>
        int CommentCount { get; }

        /// <summary>
        /// Gets the PostedBy.
        /// </summary>
        string PostedBy { get; }

        /// <summary>
        /// Gets the Score.
        /// </summary>
        int Score { get; }

        /// <summary>
        /// Gets the Time.
        /// </summary>
        DateTime? Time { get; }

        /// <summary>
        /// Gets the Title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        string Uri { get; }
    }
}