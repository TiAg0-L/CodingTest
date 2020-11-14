using System.Collections.Generic;

namespace HackerNews.Provider.Models
{
    public sealed class Item : IItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string By { get; set; }
        public string Time { get; set; }
        public string Descendants { get; set; }
        public string Score { get; set; }
        public string Id { get; set; }
        public IEnumerable<string> Kids { get; set; }
        public string Type { get; set; }
    }
}
