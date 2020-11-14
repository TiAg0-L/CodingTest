using System.Collections.Generic;

namespace HackerNews.Provider.Models
{
    public interface IItem
    {
        string By { get; set; }
        string Descendants { get; set; }
        string Id { get; set; }
        IEnumerable<string> Kids { get; set; }
        int Score { get; set; }
        string Time { get; set; }
        string Title { get; set; }
        string Type { get; set; }
        string Url { get; set; }
    }
}