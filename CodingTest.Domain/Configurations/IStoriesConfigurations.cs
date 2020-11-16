namespace CodingTest.Domain.Configurations
{
    /// <summary>
    /// Represents all configurations for stories.
    /// </summary>
    public interface IStoriesConfigurations
    {
        /// <summary>
        /// A story time to live.
        /// </summary>
        int StoryTimeToLiveInSeconds { get; set; }
    }
}