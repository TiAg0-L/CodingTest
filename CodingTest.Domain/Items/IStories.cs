using System.Collections.Generic;

namespace CodingTest.Domain.Items
{
    /// <summary>
    /// Represents an item collection.
    /// </summary>
    public interface IStories
    {
        /// <summary>
        /// Gets the 20 best Stories.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IStory> Get20BestStories();
    }
}