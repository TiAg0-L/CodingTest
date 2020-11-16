namespace CodingTest.Domain.Configurations
{
    /// <summary>
    /// Represents all configurations for stories.
    /// </summary>
    public sealed class StoriesConfigurations : IStoriesConfigurations
    {
        /// <summary>
        /// A story time to live.
        /// </summary>
        public int StoryTimeToLiveInSeconds { get; set; }
    }
}
